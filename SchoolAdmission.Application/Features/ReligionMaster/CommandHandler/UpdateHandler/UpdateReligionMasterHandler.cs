using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Application.Features.ReligionMasters.Commands;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.ReligionMaster.Handlers;

public class UpdateReligionMasterHandler(
        IReligionMasterRepository repository,
        IMapper mapper,
        ILogger<UpdateReligionMasterHandler> logger,
        ApplicationDbContext context
    ) : IRequestHandler<UpdateReligionMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(UpdateReligionMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var isExist = await repository.IsExistsAsync(request.Religion!, OperationType.Update, request.ReligionId, cancellationToken);
            
            if (isExist)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = MessageHelper.AlreadyExists(request.Religion!),
                    StatusCode = HttpStatusCode.Conflict.GetHashCode()
                };
            }
            var entity = await repository.GetByIdAsync(request.ReligionId, cancellationToken);

            if (entity == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = MessageHelper.NotFound(EntityEnum.ReligionMaster, request.ReligionId),
                    StatusCode = HttpStatusCode.NotFound.GetHashCode()
                };
            }
  
            mapper.Map(request, entity);

            await repository.Update(entity,cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(
                true,
                MessageHelper.UpdatedSuccessfully(EntityEnum.ReligionMaster),
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex, "Error while updating ReligionMaster with Id {Id}", request.ReligionId);

            return new ApiResponse<bool>
            {
                Success = false,
                Message = MessageHelper.InternalServerError(EntityEnum.ReligionMaster),
                StatusCode = HttpStatusCode.InternalServerError.GetHashCode()
            };
        }
    }
}
