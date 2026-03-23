using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System.Net;
using SchoolAdmission.Domain.Utils;

namespace SchoolAdmission.Application.Features.SchoolMasters.Commands;

public class DeleteSchoolMasterHandler(
        ISchoolMasterRepository repository, 
        ILogger<DeleteSchoolMasterHandler> logger, 
        ApplicationDbContext context
    ) : IRequestHandler<DeleteSchoolMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(DeleteSchoolMasterCommand request, CancellationToken cancellationToken)
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
                    Message = MessageHelper.NotFound(EntityEnum.SchoolMaster, request.Id),
                    StatusCode = HttpStatusCode.NotFound.GetHashCode()
                };
            }

            await repository.DeleteAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(
                true,
                MessageHelper.DeletedSuccessfully(EntityEnum.SchoolMaster),
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError("An error occurred while deleting SchoolMaster with Id {Id}", request.Id);

            return ApiResponse<bool>.FailureResponse(
                MessageHelper.InternalServerError(EntityEnum.SchoolMaster),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}
