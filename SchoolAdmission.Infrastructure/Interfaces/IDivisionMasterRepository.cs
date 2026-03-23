using SchoolAdmission.Domain;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IDivisionMasterRepository
{
    Task<List<DivisionMaster>> GetAllAsync(CancellationToken cancellationToken);

    Task<DivisionMaster?> GetByIdWithAsync(int id, CancellationToken cancellationToken);
 
    Task<DivisionMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(DivisionMaster division, CancellationToken cancellationToken);

    Task UpdateAsync(DivisionMaster division, CancellationToken cancellationToken);

    Task DeleteAsync(DivisionMaster division, CancellationToken cancellationToken);

    Task<bool> IsExistsAsync(string DivisionName, CancellationToken cancellationToken);
}
