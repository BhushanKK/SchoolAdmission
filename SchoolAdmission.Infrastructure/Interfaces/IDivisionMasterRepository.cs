using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

public interface IDivisionMasterRepository
{
    Task<List<DivisionMasterQueryDto>> GetAllAsync(CancellationToken cancellationToken);

    Task<DivisionMasterQueryDto?> GetByIdWithAsync(int id, CancellationToken cancellationToken);

    // ADD THIS METHOD
    Task<DivisionMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(DivisionMaster division, CancellationToken cancellationToken);

    Task Update(DivisionMaster division, CancellationToken cancellationToken);

    Task Delete(DivisionMaster division, CancellationToken cancellationToken);
}