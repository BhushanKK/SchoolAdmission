using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.StudentSubjectChoice.Commands;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Infrastructure.Interfaces;
using System.Net;
using SchoolAdmission.Domain.Utils;
using static SchoolAdmission.Domain.Utils.CommanEnums;
using SchoolAdmission.Domain.Entities;

public class CreateStudentSubjectChoiceHandler(
    IMapper mapper,
    ILogger<CreateStudentSubjectChoiceHandler> logger,
    ApplicationDbContext context,
    IStudentSubjectChoiceRepository studentSubjectChoiceRepository
) : IRequestHandler<CreateStudentSubjectChoiceCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(
        CreateStudentSubjectChoiceCommand request,
        CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var isExist = await studentSubjectChoiceRepository.IsExistsAsync(
                request.StudentId,
                request.SubjectId,
                OperationType.Create,
                request.ChoiceId,
                cancellationToken);

            if (isExist)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Message = "Student Subject Choice already exists",
                    StatusCode = HttpStatusCode.Conflict.GetHashCode()
                };
            }

            var entity = mapper.Map<StudentSubjectChoice>(request);
            
            await context.studentSubjectChoice.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<int>.SuccessResponse(
                entity.SubjectId,
                MessageHelper.CreatedSuccessfully(EntityEnum.StudentSubjectChoice),
                HttpStatusCode.Created.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);

            logger.LogError(ex, "Error while creating StudentSubjectChoice");

            return ApiResponse<int>.FailureResponse(
                MessageHelper.InternalServerError(EntityEnum.StudentSubjectChoice),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}