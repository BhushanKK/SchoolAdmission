using System.Net;
using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CategoryMasters.Commands;

public class UpdateCategoryMasterHandler(
    ICategoryMasterRepository repository,
    IMapper mapper,
    ApplicationDbContext context,
    ILogger<UpdateCategoryMasterHandler> logger)
    : IRequestHandler<UpdateCategoryMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(UpdateCategoryMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var entity = await repository.GetByIdAsync(request.CategoryId, cancellationToken);

            if (entity is null)
                return ApiResponse<bool>.FailureResponse(
                    MessageHelper.NotFound(EntityEnum.CategoryMaster, request.CategoryId),
                    HttpStatusCode.NotFound.GetHashCode());

            mapper.Map(request, entity);

            await repository.Update(entity, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(
                true,
                MessageHelper.UpdatedSuccessfully(EntityEnum.CategoryMaster),
                HttpStatusCode.OK.GetHashCode());
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);

            logger.LogError(ex,
                "Error while updating CategoryMaster Id : {Id}",
                request.CategoryId);

            return ApiResponse<bool>.FailureResponse(
                "Unable to update CategoryMaster at the moment.",
                HttpStatusCode.InternalServerError.GetHashCode());
        }
    }
}
