using MediatR;
using AutoMapper;
using SchoolAdmission.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Infrastructure.Interfaces;
using System.Net;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Domain.ResponseModels;
using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Application.Features.StudentSubjectChoice.Commands;

public class CreateStudentSubjectChoiceHandler(
    IMapper mapper,
    ILogger<CreateStudentSubjectChoiceHandler> logger,
    ApplicationDbContext context,
    IStudentSubjectChoiceRepository studentSubjectChoiceRepository,
    IStudentSubjectStepRepository studentSubjectStepRepository
) : IRequestHandler<CreateStudentSubjectChoiceCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(
        CreateStudentSubjectChoiceCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var isExist = await context.studentSubjectChoice.AnyAsync(x =>
                x.StudentId == request.First().StudentId,
                cancellationToken);

            if (isExist)
            {
                await context.studentSubjectChoice
                    .Where(x => x.StudentId == request.First().StudentId)
                    .ExecuteDeleteAsync(cancellationToken);
            }

            var entity = mapper.Map<List<StudentSubjectChoice>>(request);
            await context.studentSubjectChoice.AddRangeAsync(entity);
            await studentSubjectStepRepository.SaveStudentSubjectAsync(request.First().StudentId, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            
            return ApiResponse<int>.SuccessResponse(
                entity.First().StudentId.GetHashCode(),
                MessageHelper.CreatedSuccessfully(EntityEnum.StudentSubjectChoice),
                HttpStatusCode.Created.GetHashCode());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while creating StudentSubjectChoice");

            return ApiResponse<int>.FailureResponse(
                MessageHelper.InternalServerError(EntityEnum.StudentSubjectChoice),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}