using SchoolAdmission.Domain;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface ICasteMasterRepository
{
    Task<List<CasteMaster>> GetAllAsync(CancellationToken cancellationToken);

    Task<CasteMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<CasteMaster?> GetByIdWithCategoryAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(CasteMaster caste, CancellationToken cancellationToken);

    Task UpdateAsync(CasteMaster caste, CancellationToken cancellationToken);

    Task DeleteAsync(CasteMaster caste, CancellationToken cancellationToken);

    Task<bool> IsExistsAsync(string caste, CancellationToken cancellationToken);
}