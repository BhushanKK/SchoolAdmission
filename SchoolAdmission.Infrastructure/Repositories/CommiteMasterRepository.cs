using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;

public class CommiteMasterRepository(ApplicationDbContext context) : ICommiteMasterRepository
{
    // Get all CommiteMasters as entities
    public async Task<List<CommiteMaster>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.CommiteMasters
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    // Get by ID as entity
    public async Task<CommiteMaster?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.CommiteMasters
            .FindAsync(new object[] { id }, cancellationToken);
    }

    // Add new CommiteMaster
    public async Task AddAsync(CommiteMaster division, CancellationToken cancellationToken)
    {
        await context.CommiteMasters.AddAsync(division, cancellationToken);
    }

    // Update existing CommiteMaster
    public async Task UpdateAsync(CommiteMaster division, CancellationToken cancellationToken)
    {
        context.CommiteMasters.Update(division);
    }

    // Delete CommiteMaster
    public async Task DeleteAsync(CommiteMaster division, CancellationToken cancellationToken)
    {
        context.CommiteMasters.Remove(division);
    }

    public async Task<bool> IsExistsAsync(string CommiteeName, CancellationToken cancellationToken)
    {
        return await context.CommiteMasters
        .AnyAsync(x => x.CommiteeName == CommiteeName, cancellationToken);
    }
}