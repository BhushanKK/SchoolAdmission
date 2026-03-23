using System.Net;
using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;
public class DeleteCasteMasterHandler(ICasteMasterRepository repository,ApplicationDbContext context, ILogger<DeleteCasteMasterHandler> logger)
    : IRequestHandler<DeleteCasteMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(DeleteCasteMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

            if (entity is null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = MessageHelper.NotFound(EntityEnum.CasteMaster, request.Id),
                    StatusCode = HttpStatusCode.NotFound.GetHashCode()
                };
            }

            await repository.DeleteAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return ApiResponse<bool>.SuccessResponse(true, MessageHelper.DeletedSuccessfully(EntityEnum.CasteMaster), HttpStatusCode.OK.GetHashCode());
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex.Message, "Failed to delete CasteMaster");
            return ApiResponse<bool>.FailureResponse(MessageHelper.InternalServerError(EntityEnum.CasteMaster), HttpStatusCode.InternalServerError.GetHashCode());
        }
    }
}
