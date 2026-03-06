using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Data;

namespace SchoolAdmission.Infrastructure.Repositories;

public class DivisionMasterRepository(ApplicationDbContext context) : IDivisionMasterRepository
{
    public async Task<List<DivisionMaster>> GetAllAsync(CancellationToken cancellationToken)
        => await context.DivisionMasters
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<DivisionMaster?> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await context.DivisionMasters
            .FindAsync(new object[] { id }, cancellationToken);

    public async Task AddAsync(DivisionMaster Division, CancellationToken cancellationToken)
        => await context.DivisionMasters.AddAsync(Division, cancellationToken);

    public async Task Update(DivisionMaster Division, CancellationToken cancellationToken)
        => context.DivisionMasters.Update(Division);

    public async Task Delete(DivisionMaster Division, CancellationToken cancellationToken)
        => context.DivisionMasters.Remove(Division);

    Task<List<DivisionMasterQueryDto>> IDivisionMasterRepository.GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<DivisionMasterQueryDto?> GetByIdWithCategoryAsync(int id, CancellationToken cancellationToken)
{
    return await context.DivisionMasters
        .Where(x => x.DivisionId == id)
        .Select(x => new DivisionMasterQueryDto
        {
            DivisionId = x.DivisionId,
            DivisionName = x.DivisionName
        })
        .FirstOrDefaultAsync(cancellationToken);
}
}