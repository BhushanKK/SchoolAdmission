using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

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

    public async Task Update(BranchMaster branch, CancellationToken cancellationToken)
        => context.BranchMasters.Update(branch);

    public async Task Delete(BranchMaster branch, CancellationToken cancellationToken)
        => context.BranchMasters.Remove(branch);

    public async Task<bool> IsExistsAsync(string BranchName, CancellationToken cancellationToken)
    {
        return await context.BranchMasters
        .AnyAsync(x => x.BranchName == BranchName, cancellationToken);
    }
}