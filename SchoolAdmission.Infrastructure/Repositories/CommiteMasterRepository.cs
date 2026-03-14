using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;

public class CommiteMasterRepository(ApplicationDbContext context) : ICommiteMasterRepository
{
    // Get all CommiteMasters as entities
    public async Task<List<CommiteMaster>> GetAllAsyncEntities(CancellationToken cancellationToken)
    {
        return await context.CommiteMasters
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    // Get all CommiteMasters as DTOs
    public async Task<List<CommiteMasterQueryDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.CommiteMasters
            .AsNoTracking()
            .Select(x => new CommiteMasterQueryDto
            {
                CommiteeId = x.CommiteeId,
                CommiteeName = x.CommiteeName
            })
            .ToListAsync(cancellationToken);
    }

    // Get by ID as entity
    public async Task<CommiteMaster?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.CommiteMasters
            .FindAsync(new object[] { id }, cancellationToken);
    }

    // Get by ID as DTO
    public async Task<CommiteMasterQueryDto?> GetByIdWithCommiteAsync(int id, CancellationToken cancellationToken)
    {
        return await context.CommiteMasters
            .Where(x => x.CommiteeId == id)
            .Select(x => new CommiteMasterQueryDto
            {
                CommiteeId = x.CommiteeId,
                CommiteeName = x.CommiteeName
            })
            .FirstOrDefaultAsync(cancellationToken);
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