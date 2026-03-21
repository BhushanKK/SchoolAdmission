using System.Net;
using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CategoryMasters.Commands;

public class DeleteCategoryMasterCommandHandler(
    ICategoryMasterRepository repository,
    ApplicationDbContext context,
    ILogger<DeleteCategoryMasterCommandHandler> logger)
    : IRequestHandler<DeleteCategoryMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(DeleteCategoryMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

            if (entity is null)
                return ApiResponse<bool>.FailureResponse
                (
                    MessageHelper.NotFound(EntityEnum.CategoryMaster, request.Id),
                    HttpStatusCode.NotFound.GetHashCode()
                );

            await repository.Delete(entity, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse
            (
                true,
                MessageHelper.DeletedSuccessfully(EntityEnum.CategoryMaster),
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex, "Error while deleting CategoryMaster Id : {Id}", request.Id);
            return ApiResponse<bool>.FailureResponse
            (
                MessageHelper.InternalServerError(EntityEnum.CategoryMaster),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}