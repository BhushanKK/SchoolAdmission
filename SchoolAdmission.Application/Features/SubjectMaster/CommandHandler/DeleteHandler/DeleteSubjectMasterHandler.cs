using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System.Net;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.SubjectMasters.Commands;

public class DeleteSubjectMasterHandler(
        ISubjectMasterRepository repository,
        ILogger<DeleteSubjectMasterHandler> logger,
        ApplicationDbContext context
    ) : IRequestHandler<DeleteSubjectMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(DeleteSubjectMasterCommand request, CancellationToken cancellationToken)
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
                    Message = MessageHelper.NotFound(EntityEnum.SubjectMaster, request.Id),
                    StatusCode = HttpStatusCode.NotFound.GetHashCode()
                };
            }

            await repository.DeleteAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(
                true,
                MessageHelper.DeletedSuccessfully(EntityEnum.SubjectMaster),
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError("An error occurred while deleting SubjectMaster with Id {Id}", request.Id);

            return ApiResponse<bool>.FailureResponse(
                MessageHelper.InternalServerError(EntityEnum.SubjectMaster),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}