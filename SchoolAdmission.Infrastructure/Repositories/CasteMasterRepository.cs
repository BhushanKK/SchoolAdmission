using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;

namespace SchoolAdmission.Infrastructure.Repositories;

public class CasteMasterRepository(ApplicationDbContext context) : ICasteMasterRepository
{
    public async Task<List<CasteMaster>> GetAllAsync(CancellationToken cancellationToken)
        => await context.CasteMasters
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<CasteMaster?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await context.CasteMasters
            .FindAsync(new object[] { id }, cancellationToken);

    public async Task AddAsync(CasteMaster caste, CancellationToken cancellationToken)
        => await context.CasteMasters.AddAsync(caste, cancellationToken);

    public async Task Update(CasteMaster caste, CancellationToken cancellationToken)
        => context.CasteMasters.Update(caste);

    public async Task Delete(CasteMaster caste, CancellationToken cancellationToken)
        => context.CasteMasters.Remove(caste);
}