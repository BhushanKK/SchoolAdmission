using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Application.Features.DivisionMasters.Commands;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CommandHandler.UpdateHandler;

public class UpdateDivisionMasterHandler(
    IDivisionMasterRepository repository,
    IMapper mapper,
    ILogger<UpdateDivisionMasterHandler> logger,
    ApplicationDbContext context
) : IRequestHandler<UpdateDivisionMasterCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(UpdateDivisionMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            
            var entity = await repository.GetByIdAsync(request.DivisionId, cancellationToken);

            if (entity == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = MessageHelper.NotFound(EntityEnum.DivisionMaster, request.DivisionId),
                    StatusCode = HttpStatusCode.NotFound.GetHashCode()
                };
            }

            
            mapper.Map(request, entity);

            
            await repository.UpdateAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            
            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(
                true,
                MessageHelper.UpdatedSuccessfully(EntityEnum.DivisionMaster),
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex, "Error while updating DivisionMaster with Id {Id}", request.DivisionId);

            return new ApiResponse<bool>
            {
                Success = false,
                Message = MessageHelper.InternalServerError(EntityEnum.DivisionMaster),
                StatusCode = HttpStatusCode.InternalServerError.GetHashCode()
            };
        }
    }
}
