using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;

public class StandardMasterRepository(ApplicationDbContext context) : IStandardMasterRepository
{
    public async Task<List<StandardMaster>> GetAllAsync(CancellationToken cancellationToken)
        => await context.StandardMasters
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<StandardMaster?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await context.StandardMasters
            .FindAsync(new object[] { id }, cancellationToken);

    public async Task<int> AddAsync(StandardMaster entity, CancellationToken cancellationToken = default)
    {
        await context.StandardMasters.AddAsync(entity, cancellationToken);
        return await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> UpdateAsync(StandardMaster entity, CancellationToken cancellationToken = default)
    {
        context.StandardMasters.Update(entity);
        return await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> DeleteAsync(StandardMaster entity, CancellationToken cancellationToken = default)
    
    {
        context.StandardMasters.Remove(entity);
        return await context.SaveChangesAsync(cancellationToken);
    }
    

    public async Task<bool> IsExistsAsync(string standardName, CancellationToken cancellationToken)
    {
        return await context.StandardMasters
            .AnyAsync(x => x.StandardName == standardName, cancellationToken);
    }
}