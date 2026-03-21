using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface ICasteMasterRepository
{
    Task<List<CasteMasterQueryDto>> GetAllAsync(CancellationToken cancellationToken);

    Task<CasteMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<CasteMasterQueryDto?> GetByIdWithCategoryAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(CasteMaster caste, CancellationToken cancellationToken);

    Task UpdateAsync(CasteMaster caste, CancellationToken cancellationToken);

    Task DeleteAsync(CasteMaster caste, CancellationToken cancellationToken);

    Task<bool> IsExistsAsync(string caste, CancellationToken cancellationToken);
    

}