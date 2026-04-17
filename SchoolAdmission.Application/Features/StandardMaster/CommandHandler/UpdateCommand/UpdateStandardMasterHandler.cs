using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Application.Features.StandardMasters.Commands;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StandardMasters.Handlers;

public class UpdateStandardMasterHandler(
        IStandardMasterRepository repository,
        IMapper mapper,
        ILogger<UpdateStandardMasterHandler> logger,
        ApplicationDbContext context
    ) : IRequestHandler<UpdateStandardMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(UpdateStandardMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction =
            await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {   
            var isExist = await repository.IsExistsAsync(request.StandardName!, OperationType.Update, request.StandardId, cancellationToken);
            if (isExist)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = MessageHelper.AlreadyExists(request.StandardName!),
                    StatusCode = HttpStatusCode.Conflict.GetHashCode()
                };
            }
            var entity = await repository.GetByIdAsync(request.StandardId, cancellationToken);

            if (entity == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = MessageHelper.NotFound(EntityEnum.StandardMaster, request.StandardId),
                    StatusCode = HttpStatusCode.NotFound.GetHashCode()
                };
            }
 
            mapper.Map(request, entity);

            await repository.UpdateAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(
                true,
                MessageHelper.UpdatedSuccessfully(EntityEnum.StandardMaster),
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex, "Error while updating StandardMaster with Id {Id}", request.StandardId);

            return new ApiResponse<bool>
            {
                Success = false,
                Message = MessageHelper.InternalServerError(EntityEnum.StandardMaster),
                StatusCode = HttpStatusCode.InternalServerError.GetHashCode()
            };
        }
    }
}
