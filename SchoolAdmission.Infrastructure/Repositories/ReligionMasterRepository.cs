using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;

public class ReligionMasterRepository(ApplicationDbContext context) : IReligionMasterRepository
{
    // Get all
    public async Task<List<ReligionMaster>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.ReligionMasters
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    // Get by Id
    public async Task<ReligionMaster?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.ReligionMasters
            .FindAsync(new object[] { id }, cancellationToken);
    }

    // Add
    public async Task<int> AddAsync(ReligionMaster entity, CancellationToken cancellationToken = default)
    {
        await context.ReligionMasters.AddAsync(entity, cancellationToken);
        return await context.SaveChangesAsync(cancellationToken);
    }

    // Update
    public async Task<int> UpdateAsync(ReligionMaster entity, CancellationToken cancellationToken = default)
    {
        context.ReligionMasters.Update(entity);
        return await context.SaveChangesAsync(cancellationToken);
    }

    // Delete
    public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await context.ReligionMasters.FindAsync(new object[] { id }, cancellationToken);
        if (entity != null)
        {
            context.ReligionMasters.Remove(entity);
            return await context.SaveChangesAsync(cancellationToken);
        }
        return 0;
    }

    public async Task<bool> IsExistsAsync(string Religion, CancellationToken cancellationToken)
    {
        return await context.ReligionMasters
        .AnyAsync(x => x.Religion == Religion, cancellationToken);
    }
}