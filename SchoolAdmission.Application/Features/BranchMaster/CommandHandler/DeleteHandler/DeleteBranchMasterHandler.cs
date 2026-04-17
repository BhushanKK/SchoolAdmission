using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System.Net;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.BranchMasters.Commands;

public class DeleteBranchMasterHandler(IBranchMasterRepository repository, 
ILogger<DeleteBranchMasterHandler> logger, ApplicationDbContext context)
    : IRequestHandler<DeleteBranchMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(DeleteBranchMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = MessageHelper.NotFound(EntityEnum.BranchMaster, request.Id),
                    StatusCode = HttpStatusCode.NotFound.GetHashCode()
                };
            }

            await repository.DeleteAsync(entity, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(true, MessageHelper.DeletedSuccessfully(EntityEnum.BranchMaster), HttpStatusCode.OK.GetHashCode());
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError("An error occurred while deleting BranchMaster with Id {Id}", request.Id);
            return ApiResponse<bool>.FailureResponse(MessageHelper.InternalServerError(EntityEnum.BranchMaster), HttpStatusCode.InternalServerError.GetHashCode());
        }
    }
}
