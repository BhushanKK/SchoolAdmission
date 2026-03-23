using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System.Net;
using SchoolAdmission.Domain.Utils;

namespace SchoolAdmission.Application.Features.ReligionMasters.Commands;

public class DeleteReligionMasterHandler(
        IReligionMasterRepository repository,
        ILogger<DeleteReligionMasterHandler> logger,
        ApplicationDbContext context
    ) : IRequestHandler<DeleteReligionMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(DeleteReligionMasterCommand request, CancellationToken cancellationToken)
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
                    Message = MessageHelper.NotFound(EntityEnum.ReligionMaster, request.Id),
                    StatusCode = HttpStatusCode.NotFound.GetHashCode()
                };
            }

            await repository.DeleteAsync(entity, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(
                true,
                MessageHelper.DeletedSuccessfully(EntityEnum.ReligionMaster),
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError("An error occurred while deleting ReligionMaster with Id {Id}", request.Id);
            return ApiResponse<bool>.FailureResponse(
                MessageHelper.InternalServerError(EntityEnum.ReligionMaster),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}
