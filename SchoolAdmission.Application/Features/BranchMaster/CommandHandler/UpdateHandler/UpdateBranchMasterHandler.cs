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

namespace SchoolAdmission.Application.Features.CommandHandler.UpdateHandler;
public class UpdateBranchMasterHandler(IBranchMasterRepository repository,
    IMapper mapper,ILogger<UpdateBranchMasterHandler> logger,ApplicationDbContext context)
    : IRequestHandler<UpdateBranchMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(UpdateBranchMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction =
            await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var isExist = await repository.IsExistsAsync(request.BranchName!, OperationType.Update, request.BranchId, cancellationToken);
            
            if (isExist)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = MessageHelper.AlreadyExists(request.BranchName!),
                    StatusCode = HttpStatusCode.Conflict.GetHashCode()
                };
            }

            var entity = await repository.GetByIdAsync(request.BranchId, cancellationToken);

            if (entity == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = MessageHelper.NotFound(EntityEnum.BranchMaster, request.BranchId),
                    StatusCode = HttpStatusCode.NotFound.GetHashCode()
                };
            }

            mapper.Map(request, entity);
            await repository.UpdateAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return ApiResponse<bool>.SuccessResponse(true, MessageHelper.UpdatedSuccessfully(EntityEnum.BranchMaster), HttpStatusCode.OK.GetHashCode());
        }
        
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex,"Error while updating BranchMaster with Id {Id}",request.BranchId);
            return new ApiResponse<bool>
            {
                Success = false,
                Message = MessageHelper.InternalServerError(EntityEnum.BranchMaster),
                StatusCode = HttpStatusCode.InternalServerError.GetHashCode()
            };
        }
    }
}
