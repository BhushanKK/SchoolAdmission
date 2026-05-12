using MediatR;
using AutoMapper;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Domain.ResponseModels;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Application.Features.StudentSubjectChoice.Commands;

public class CreateStudentSubjectChoiceHandler(
    IMapper mapper,
    ILogger<CreateStudentSubjectChoiceHandler> logger,
    ApplicationDbContext context,
    IStudentSubjectStepRepository studentSubjectStepRepository
) : IRequestHandler<CreateStudentSubjectChoiceCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(
        CreateStudentSubjectChoiceCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var studentId = request.First().StudentId;

            await context.studentSubjectChoice
                .Where(x => x.StudentId == studentId)
                .ExecuteDeleteAsync(cancellationToken);

            var entities = mapper.Map<List<StudentSubjectChoice>>(request);

            await context.studentSubjectChoice.AddRangeAsync(entities, cancellationToken);
            await studentSubjectStepRepository.SaveStudentSubjectAsync(studentId, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return ApiResponse<int>.SuccessResponse(
                studentId.GetHashCode(),
                MessageHelper.CreatedSuccessfully(EntityEnum.StudentSubjectChoice),
                HttpStatusCode.Created.GetHashCode());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while creating StudentSubjectChoice for StudentId: {StudentId}",
                request?.FirstOrDefault()?.StudentId);

            return ApiResponse<int>.FailureResponse(
                MessageHelper.InternalServerError(EntityEnum.StudentSubjectChoice),
                HttpStatusCode.InternalServerError.GetHashCode());
        }
    }
}