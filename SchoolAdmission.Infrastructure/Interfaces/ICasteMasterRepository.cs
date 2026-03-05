using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

public interface ICasteMasterRepository
{
    Task<List<CasteMasterDto>> GetAllAsync(CancellationToken cancellationToken);

    Task<CasteMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(CasteMaster caste, CancellationToken cancellationToken);

    Task Update(CasteMaster caste, CancellationToken cancellationToken);

    Task Delete(CasteMaster caste, CancellationToken cancellationToken);
}