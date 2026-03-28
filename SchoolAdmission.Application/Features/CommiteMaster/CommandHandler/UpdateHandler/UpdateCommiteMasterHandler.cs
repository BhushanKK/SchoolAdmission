using System.Net;
using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Application.Features.CommiteMasters.Commands;

public class UpdateCommiteMasterHandler(
    ICommiteMasterRepository repository,
    IMapper mapper,
    ApplicationDbContext context,
    ILogger<UpdateCommiteMasterHandler> logger)
    : IRequestHandler<UpdateCommiteMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(UpdateCommiteMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {   
            var isExist = await repository.IsExistsAsync(request.CommiteeName!, OperationType.Update, request.CommiteeId, cancellationToken);
            
            if (isExist)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = MessageHelper.AlreadyExists(request.CommiteeName!),
                    StatusCode = HttpStatusCode.Conflict.GetHashCode()
                };
            }
            var entity = await repository.GetByIdAsync(request.CommiteeId, cancellationToken);

            if (entity is null)
                return ApiResponse<bool>.FailureResponse
                (
                    MessageHelper.NotFound(EntityEnum.CommiteMaster, request.CommiteeId),
                    HttpStatusCode.NotFound.GetHashCode()
                );

            mapper.Map(request, entity);

            await repository.UpdateAsync(entity, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse
            (
                true,
                MessageHelper.UpdatedSuccessfully(EntityEnum.CommiteMaster),
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex,"Error while updating CommiteMaster Id : {Id}",request.CommiteeId);
            return ApiResponse<bool>.FailureResponse
            (
                MessageHelper.InternalServerError(EntityEnum.CommiteMaster),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}
