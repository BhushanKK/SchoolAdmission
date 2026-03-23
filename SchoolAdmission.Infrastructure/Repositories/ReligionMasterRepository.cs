using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;

public class ReligionMasterRepository(ApplicationDbContext context) : IReligionMasterRepository
{
    public async Task<List<ReligionMaster>> GetAllAsync(CancellationToken cancellationToken)
        => await context.ReligionMasters
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<ReligionMaster?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await context.ReligionMasters
            .FindAsync(new object[] { id }, cancellationToken);

    public async Task AddAsync(ReligionMaster religion, CancellationToken cancellationToken)
        => await context.ReligionMasters.AddAsync(religion, cancellationToken);

    public async Task UpdateAsync(ReligionMaster religion, CancellationToken cancellationToken)
        => context.ReligionMasters.Update(religion);

    public async Task DeleteAsync(ReligionMaster religion, CancellationToken cancellationToken)
        => context.ReligionMasters.Remove(religion);

    public async Task<bool> IsExistsAsync(string religionName, CancellationToken cancellationToken)
    {
        return await context.ReligionMasters
            .AnyAsync(x => x.Religion == religionName, cancellationToken);
    }
}
