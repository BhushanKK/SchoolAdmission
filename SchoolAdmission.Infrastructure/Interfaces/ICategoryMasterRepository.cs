using SchoolAdmission.Domain;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface ICategoryMasterRepository
{
    Task<List<CategoryMaster>> GetAllAsync(CancellationToken cancellationToken);

    Task<CategoryMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(CategoryMaster category, CancellationToken cancellationToken);

    Task UpdateAsync(CategoryMaster category, CancellationToken cancellationToken);

    Task DeleteAsync(CategoryMaster category, CancellationToken cancellationToken);

    Task<bool> IsExist(string name, CancellationToken cancellationToken);

    Task<bool> IsExistsAsync(string Category, CancellationToken cancellationToken);
}