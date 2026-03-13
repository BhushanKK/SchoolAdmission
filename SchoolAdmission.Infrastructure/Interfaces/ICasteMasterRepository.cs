using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

public interface ICasteMasterRepository
{
    Task<List<CasteMasterQueryDto>> GetAllAsync(CancellationToken cancellationToken);

    Task<CasteMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<CasteMasterQueryDto?> GetByIdWithCategoryAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(CasteMaster caste, CancellationToken cancellationToken);

    Task Update(CasteMaster caste, CancellationToken cancellationToken);

    Task Delete(CasteMaster caste, CancellationToken cancellationToken);

    Task<bool> IsExistsAsync(string caste, CancellationToken cancellationToken);
    

}