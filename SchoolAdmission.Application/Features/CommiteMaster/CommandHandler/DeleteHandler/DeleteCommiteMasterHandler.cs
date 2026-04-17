using System.Net;
using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Domain.ResponseModels;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CommiteMasters.Commands;

public class DeleteCommiteMasterCommandHandler(
    ICommiteMasterRepository repository,
    ApplicationDbContext context,
    ILogger<DeleteCommiteMasterCommandHandler> logger
) : IRequestHandler<DeleteCommiteMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(DeleteCommiteMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

            if (entity is null)
                return ApiResponse<bool>.FailureResponse
                (
                    MessageHelper.NotFound(EntityEnum.CommiteMaster, request.Id),
                    HttpStatusCode.NotFound.GetHashCode()
                );

            await repository.DeleteAsync(entity, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse
            (
                true,
                MessageHelper.DeletedSuccessfully(EntityEnum.CommiteMaster),
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);

            logger.LogError(ex, "Error while deleting CommiteMaster Id : {Id}", request.Id);

            return ApiResponse<bool>.FailureResponse
            (
                MessageHelper.InternalServerError(EntityEnum.CommiteMaster),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}
