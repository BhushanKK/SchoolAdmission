using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Application.Features.StudentSubjectChoice.Commands;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.CommandHandler.UpdateHandler;

public class UpdateStudentSubjectChoiceHandler(
    IStudentSubjectChoiceRepository repository,
    IMapper mapper,
    ILogger<UpdateStudentSubjectChoiceHandler> logger,
    ApplicationDbContext context
) : IRequestHandler<UpdateStudentSubjectChoiceCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(
        UpdateStudentSubjectChoiceCommand request,
        CancellationToken cancellationToken)
    {
        await using var transaction =
            await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var isExist = await repository.IsExistsAsync(
                request.StudentId!,
                request.SubjectId,
                OperationType.Update,
                request.ChoiceId,
                cancellationToken);

            if (isExist)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = "Student Subject Choice already exists",
                    StatusCode = HttpStatusCode.Conflict.GetHashCode()
                };
            }

            var entity = await repository.GetByIdAsync(request.ChoiceId, cancellationToken);

            if (entity == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = MessageHelper.NotFound(EntityEnum.StudentSubjectChoice, request.ChoiceId),
                    StatusCode = HttpStatusCode.NotFound.GetHashCode()
                };
            }

            mapper.Map(request, entity);

            await repository.UpdateAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(
                true,
                MessageHelper.UpdatedSuccessfully(EntityEnum.StudentSubjectChoice),
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);

            logger.LogError(ex,
                "Error while updating StudentSubjectChoice with Id {Id}",
                request.ChoiceId);

            return new ApiResponse<bool>
            {
                Success = false,
                Message = MessageHelper.InternalServerError(EntityEnum.StudentSubjectChoice),
                StatusCode = HttpStatusCode.InternalServerError.GetHashCode()
            };
        }
    }
}