using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Application.Common.Exceptions;

namespace SchoolAdmission.Application.Features.BranchMasters.Commands;

public class DeleteBranchMasterCommandHandler(IBranchMasterRepository repository, ILogger<DeleteBranchMasterCommandHandler> logger, ApplicationDbContext context)
    : IRequestHandler<DeleteBranchMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(DeleteBranchMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

            if (entity is null)
                if (entity == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = $"BranchMaster with Id {request.Id} not found",
                    StatusCode = 404
                };
            }

            await repository.DeleteAsync(entity, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(true, "Branch deleted successfully", 200);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError("An error occurred while deleting BranchMaster with Id {Id}", request.Id);
            throw new ApiException($"An error occurred while deleting BranchMaster with Id {request.Id}");
        }
    }
}