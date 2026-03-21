using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;

public class FeesStructureDetailsRepository(ApplicationDbContext context) : IFeesStructureDetailsRepository
{
    // Get all
    public async Task<List<FeesStructureQueryDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.FeesStructureDetails
            .AsNoTracking()
            .Select(f => new FeesStructureQueryDto
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
    public async Task<FeesStructureDetails?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var fee = await context.FeesStructureDetails
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.FeeId == id, cancellationToken);

        if (fee == null) return null;

        return fee;
    }

    // Add
    public async Task AddAsync(FeesStructureDetails entity, CancellationToken cancellationToken = default)
    {
        await context.FeesStructureDetails.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    // Update
    public async Task UpdateAsync(FeesStructureDetails entity, CancellationToken cancellationToken = default)
    {
        context.FeesStructureDetails.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    // Delete
    public async Task DeleteAsync(FeesStructureDetails entity, CancellationToken cancellationToken = default)
    {
        context.FeesStructureDetails.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

}
