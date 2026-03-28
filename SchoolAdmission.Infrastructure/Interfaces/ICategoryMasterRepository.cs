using SchoolAdmission.Domain;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface ICategoryMasterRepository
{
    Task<List<CategoryMaster>> GetAllAsync(CancellationToken cancellationToken);

    Task<CategoryMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(CategoryMaster category, CancellationToken cancellationToken);

    Task Update(CategoryMaster category, CancellationToken cancellationToken);

    Task Delete(CategoryMaster category, CancellationToken cancellationToken);

    Task<bool> IsExistsAsync(string Category, OperationType operation, int? CategoryId, CancellationToken cancellationToken);
}
