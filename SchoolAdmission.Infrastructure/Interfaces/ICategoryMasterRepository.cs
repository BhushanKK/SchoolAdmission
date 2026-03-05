using SchoolAdmission.Domain;

public interface ICategoryMasterRepository
{
    Task<List<CategoryMaster>> GetAllAsync(CancellationToken cancellationToken);

    Task<CategoryMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(CategoryMaster category, CancellationToken cancellationToken);

    Task Update(CategoryMaster category, CancellationToken cancellationToken);

    Task Delete(CategoryMaster category, CancellationToken cancellationToken);
}