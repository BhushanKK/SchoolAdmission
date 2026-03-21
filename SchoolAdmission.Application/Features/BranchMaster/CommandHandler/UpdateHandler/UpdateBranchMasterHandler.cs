using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Application.Features.BranchMasters.Commands;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CommandHandler.UpdateHandler;
public class UpdateBranchMasterHandler(
    IBranchMasterRepository repository,
    IMapper mapper,
    ILogger<UpdateBranchMasterHandler> logger,
    ApplicationDbContext context)
    : IRequestHandler<UpdateBranchMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(UpdateBranchMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction =
            await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var entity = await repository.GetByIdAsync(request.BranchId, cancellationToken);

            if (entity == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = $"BranchMaster with Id {request.BranchId} not found",
                    StatusCode = 404
                };
            }

            mapper.Map(request, entity);

            await repository.UpdateAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(true, "Branch updated successfully", 200);
        }
        
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);

            logger.LogError(ex,
                "Error while updating BranchMaster with Id {Id}",
                request.BranchId);

            return new ApiResponse<bool>
            {
                Success = false,
                Message = "Unable to update BranchMaster at the moment. Please try again later.",
                StatusCode = 500
            };
        }
    }
}