using Microsoft.EntityFrameworkCore;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;

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

    public async Task UpdateAsync(DivisionMaster Division, CancellationToken cancellationToken)
        => context.DivisionMasters.Update(Division);

    public async Task DeleteAsync(DivisionMaster Division, CancellationToken cancellationToken)
        => context.DivisionMasters.Remove(Division);

    public async Task<bool> IsExistsAsync(string DivisionName, OperationType  operation, int? DivisionId, CancellationToken cancellationToken)
    {
        if (operation == OperationType.Create)
            return await context.DivisionMasters.AnyAsync(x => x.DivisionName.ToLower() == DivisionName.ToLower(), cancellationToken);
        
        else if (operation == OperationType.Update)
            return await context.DivisionMasters.AnyAsync(x => x.DivisionName.ToLower() == DivisionName.ToLower() && x.DivisionId != DivisionId, cancellationToken);

        return false;
    }

    public Task<DivisionMaster?> GetByIdWithAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

}
