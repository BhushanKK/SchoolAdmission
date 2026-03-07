using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

public interface IDivisionMasterRepository
{
    Task<List<DivisionMasterQueryDto>> GetAllAsync(CancellationToken cancellationToken);

    Task<DivisionMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<DivisionMasterQueryDto?> GetByIdWithCategoryAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(DivisionMaster Division, CancellationToken cancellationToken);

    Task Update(DivisionMaster Division, CancellationToken cancellationToken);

    Task Delete(DivisionMaster Division, CancellationToken cancellationToken);
}