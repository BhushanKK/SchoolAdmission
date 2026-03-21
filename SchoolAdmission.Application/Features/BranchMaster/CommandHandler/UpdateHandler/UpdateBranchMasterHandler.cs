using MediatR;
using AutoMapper;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Application.Common.Exceptions;

namespace SchoolAdmission.Application.Features.BranchMasters.Commands;

public class UpdateBranchMasterHandler(IBranchMasterRepository repository,
    IMapper mapper,ILogger logger,ApplicationDbContext context)
    : IRequestHandler<UpdateBranchMasterCommand, bool>
{
    public async Task<bool> Handle(UpdateBranchMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var entity = await repository.GetByIdAsync(request.BranchId, cancellationToken);

            if (entity == null)
                throw new ApiException($"BranchMaster with Id {request.BranchId} not found");

            mapper.Map(request, entity);

            await repository.UpdateAsync(entity, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return true;
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError("An error occurred while updating BranchMaster with Id {Id}", request.BranchId);
            throw new ApiException($"An error occurred while updating BranchMaster with Id {request.BranchId}");
        }
    }
}