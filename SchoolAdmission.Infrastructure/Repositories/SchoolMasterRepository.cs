using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Infrastructure.Repositories;

public class SchoolMasterRepository(ApplicationDbContext context) : ISchoolMasterRepository
{
    public async Task<List<SchoolMaster>> GetAllAsync(CancellationToken cancellationToken)
        => await context.SchoolMasters
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<SchoolMaster?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await context.SchoolMasters
            .FindAsync(new object[] { id }, cancellationToken);

    public async Task AddAsync(SchoolMaster school, CancellationToken cancellationToken)
        => await context.SchoolMasters.AddAsync(school, cancellationToken);

    public async Task UpdateAsync(SchoolMaster school, CancellationToken cancellationToken)
        => context.SchoolMasters.Update(school);

    public async Task DeleteAsync(SchoolMaster school, CancellationToken cancellationToken)
        => context.SchoolMasters.Remove(school);

    public async Task<bool> IsExistsAsync(string schoolName, CancellationToken cancellationToken)
    {
        return await context.SchoolMasters
            .AnyAsync(x => x.SchoolName == schoolName, cancellationToken);
    }
}
