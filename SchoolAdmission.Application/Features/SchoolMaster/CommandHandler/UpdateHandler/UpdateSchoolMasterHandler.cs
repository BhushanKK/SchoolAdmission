using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Application.Features.SchoolMasters.Commands;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.SchoolMasters.Handlers;

public class UpdateSchoolMasterHandler(
        ISchoolMasterRepository repository,
        IMapper mapper,
        ILogger<UpdateSchoolMasterHandler> logger,
        ApplicationDbContext context
    ) : IRequestHandler<UpdateSchoolMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(UpdateSchoolMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {   
            var isExist = await repository.IsExistsAsync(request.SchoolName!, OperationType.Update, request.SchoolId, cancellationToken);
            
            if (isExist)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = MessageHelper.AlreadyExists(request.SchoolName!),
                    StatusCode = HttpStatusCode.Conflict.GetHashCode()
                };
            }
            var entity = await repository.GetByIdAsync(request.SchoolId, cancellationToken);

            if (entity == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = MessageHelper.NotFound(EntityEnum.SchoolMaster, request.SchoolId),
                    StatusCode = HttpStatusCode.NotFound.GetHashCode()
                };
            }

            mapper.Map(request, entity);

            await repository.UpdateAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(
                true,
                MessageHelper.UpdatedSuccessfully(EntityEnum.SchoolMaster),
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex, "Error while updating SchoolMaster with Id {Id}", request.SchoolId);

            return new ApiResponse<bool>
            {
                Success = false,
                Message = MessageHelper.InternalServerError(EntityEnum.SchoolMaster),
                StatusCode = HttpStatusCode.InternalServerError.GetHashCode()
            };
        }
    }
}
