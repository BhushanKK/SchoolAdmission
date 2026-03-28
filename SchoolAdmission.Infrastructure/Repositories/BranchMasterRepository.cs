using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Infrastructure.Repositories;

public class BranchMasterRepository(ApplicationDbContext context) : IBranchMasterRepository
{
    public async Task<List<BranchMaster>> GetAllAsync(CancellationToken cancellationToken)
        => await context.BranchMasters
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<BranchMaster?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await context.BranchMasters
            .FindAsync(new object[] { id }, cancellationToken);

    public async Task AddAsync(BranchMaster branch, CancellationToken cancellationToken)
        => await context.BranchMasters.AddAsync(branch, cancellationToken);

    public async Task UpdateAsync(BranchMaster branch, CancellationToken cancellationToken)
        => context.BranchMasters.Update(branch);

    public async Task DeleteAsync(BranchMaster branch, CancellationToken cancellationToken)
        => context.BranchMasters.Remove(branch);

    public async Task<bool> IsExistsAsync(string BranchName, OperationType  operation, int? BranchId, CancellationToken cancellationToken)
    {
        if (operation == OperationType.Create)
            return await context.BranchMasters.AnyAsync(x => x.BranchName.ToLower() == BranchName.ToLower(), cancellationToken);
        
        else if (operation == OperationType.Update)
            return await context.BranchMasters.AnyAsync(x => x.BranchName.ToLower() == BranchName.ToLower() && x.BranchId != BranchId, cancellationToken);

        return false;
    }
}
