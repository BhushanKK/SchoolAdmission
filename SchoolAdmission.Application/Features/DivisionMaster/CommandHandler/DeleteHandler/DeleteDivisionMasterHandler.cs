using System.Net;
using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.DivisionMasters.Commands;

public class DeleteDivisionMasterHandler(
    IDivisionMasterRepository repository,
    ApplicationDbContext context,
    ILogger<DeleteDivisionMasterHandler> logger
) : IRequestHandler<DeleteDivisionMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(DeleteDivisionMasterCommand request, CancellationToken cancellationToken)
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
                    Message = MessageHelper.NotFound(EntityEnum.DivisionMaster, request.Id),
                    StatusCode = HttpStatusCode.NotFound.GetHashCode()
                };
            }

            
            await repository.DeleteAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            
            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(
                true,
                MessageHelper.DeletedSuccessfully(EntityEnum.DivisionMaster),
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex, "Failed to delete DivisionMaster");

            return ApiResponse<bool>.FailureResponse(
                MessageHelper.InternalServerError(EntityEnum.DivisionMaster),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}
