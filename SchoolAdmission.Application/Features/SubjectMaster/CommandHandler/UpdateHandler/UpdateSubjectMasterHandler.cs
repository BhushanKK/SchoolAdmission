using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Application.Features.BranchMasters.Commands;
using SchoolAdmission.Domain.ResponseModels;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Application.Features.SubjectMasters.CommandHandler.UpdateHandler;

public class UpdateSubjectMasterHandler(
    ISubjectMasterRepository repository,
    IMapper mapper,
    ILogger<UpdateSubjectMasterHandler> logger,
    ApplicationDbContext context
) : IRequestHandler<UpdateSubjectMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(UpdateSubjectMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction =
            await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var isExist = await repository.IsExistsAsync(
                request.SubjectName!,
                OperationType.Update,
                request.SubjectId,
                cancellationToken
            );

            if (isExist)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = MessageHelper.AlreadyExists(request.SubjectName!),
                    StatusCode = HttpStatusCode.Conflict.GetHashCode()
                };
            }
            var entity = await repository.GetByIdAsync(request.SubjectId, cancellationToken);

            if (entity == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = MessageHelper.NotFound(EntityEnum.SubjectMaster, request.SubjectId),
                    StatusCode = HttpStatusCode.NotFound.GetHashCode()
                };
            }

            mapper.Map(request, entity);

            await repository.UpdateAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(
                true,
                MessageHelper.UpdatedSuccessfully(EntityEnum.SubjectMaster),
                (int)HttpStatusCode.OK
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);

            logger.LogError(ex, "Error while updating SubjectMaster with Id {Id}", request.SubjectId);

            return new ApiResponse<bool>
            {
                Success = false,
                Message = MessageHelper.InternalServerError(EntityEnum.SubjectMaster),
                StatusCode = HttpStatusCode.InternalServerError.GetHashCode()
            };
        }
    }
}