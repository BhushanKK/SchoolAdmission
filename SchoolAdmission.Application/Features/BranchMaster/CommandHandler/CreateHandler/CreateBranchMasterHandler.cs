using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.BranchMasters.Commands;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Application.Common.Exceptions;
using SchoolAdmission.Infrastructure.Interfaces;

public class CreateBranchMasterHandler(IMapper mapper,ILogger<CreateBranchMasterHandler> logger,
    ApplicationDbContext context,ICurrentUserRepository currentUser) : IRequestHandler<CreateBranchMasterCommand, int>
{
    public async Task<int> Handle(CreateBranchMasterCommand request,CancellationToken cancellationToken)
    {
        await using IDbContextTransaction transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        
        try
        {
            var branchMaster = mapper.Map<BranchMaster>(request);
            branchMaster.EntryBy = await currentUser.Email;
            branchMaster.EntryDate = DateTime.UtcNow;
            await context.BranchMasters.AddAsync(branchMaster, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return branchMaster.BranchId;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex.Message, "An error occurred while creating BranchMaster");
            throw new ApiException("An error occurred while creating BranchMaster");
        }
    }
}