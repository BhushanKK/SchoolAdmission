using MediatR;
using AutoMapper;
using SchoolAdmission.Infrastructure.Interfaces;
using System.Net;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using static SchoolAdmission.Domain.Utils.CommanEnums;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public class UpdateCasteMasterHandler(ICasteMasterRepository repository,ILogger<UpdateCasteMasterHandler> logger, ICurrentUserRepository currentUser,IMapper mapper, ApplicationDbContext context)
    : IRequestHandler<UpdateCasteMasterCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(UpdateCasteMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var isExist = await repository.IsExistsAsync(request.Caste!, OperationType.Update, request.CasteId, cancellationToken);
            
            if (isExist)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Message = MessageHelper.AlreadyExists(request.Caste!),
                    StatusCode = HttpStatusCode.Conflict.GetHashCode()
                };
            }

            var entity = await repository.GetByIdAsync(request.CasteId, cancellationToken);

            if (entity is null)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Message = MessageHelper.NotFound(EntityEnum.CasteMaster, request.CasteId),
                    StatusCode = HttpStatusCode.NotFound.GetHashCode()
                };
            }

            entity.CasteId = request.CasteId;
            mapper.Map(request, entity);
            entity.ModifiedDate = DateTime.UtcNow;
            entity.ModifyBy = await currentUser.Email;
            await repository.UpdateAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return ApiResponse<int>.SuccessResponse(entity.CasteId, MessageHelper.UpdatedSuccessfully(EntityEnum.CasteMaster), HttpStatusCode.OK.GetHashCode());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while updating the caste master.");
            await transaction.RollbackAsync(cancellationToken);
            return ApiResponse<int>.FailureResponse(MessageHelper.InternalServerError(EntityEnum.CasteMaster), HttpStatusCode.InternalServerError.GetHashCode());
        }
    }
}
