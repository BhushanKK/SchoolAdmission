using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;

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

    public async Task AddAsync(StandardMaster standard, CancellationToken cancellationToken)
        => await context.StandardMasters.AddAsync(standard, cancellationToken);

    public async Task Update(StandardMaster standard, CancellationToken cancellationToken)
        => context.StandardMasters.Update(standard);

    public async Task Delete(StandardMaster standard, CancellationToken cancellationToken)
        => context.StandardMasters.Remove(standard);

    Task<int> IStandardMasterRepository.AddAsync(StandardMaster entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(StandardMaster entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}