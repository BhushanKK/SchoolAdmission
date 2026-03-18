using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;

public class FeesStructureDetailRepository(ApplicationDbContext context) : IFeesStructureDetailRepository
{
// Get all
    public async Task<List<FeesStructureDetail>> GetAllAsync(CancellationToken cancellationToken )
    {
        return await context.FeesStructureDetails
            .AsNoTracking()
            .Select(f => new FeesStructureDetail
            {
                FeeId = f.FeeId,
                FeeHeadDescription = f.FeeHeadDescription,
                StandardId = f.StandardId,
                Amount = f.Amount,
                BranchId = f.BranchId
            })
            .ToListAsync(cancellationToken);
    }

    // Get by Id
    public async Task<FeesStructureDetail?> GetByIdAsync(int id, CancellationToken cancellationToken )
    {
        var fee = await context.FeesStructureDetails
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.FeeId == id, cancellationToken);

        if (fee == null) return null;

        return fee;
    }

    // Add
    public async Task AddAsync(FeesStructureDetail entity, CancellationToken cancellationToken = default)
    {
        await context.FeesStructureDetails.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    // Update
    public async Task UpdateAsync(FeesStructureDetail entity, CancellationToken cancellationToken = default)
    {
        context.FeesStructureDetails.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    // Delete
    public async Task DeleteAsync(FeesStructureDetail entity, CancellationToken cancellationToken = default)
    {
        context.FeesStructureDetails.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }
}
