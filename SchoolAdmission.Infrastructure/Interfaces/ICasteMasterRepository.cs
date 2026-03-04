using SchoolAdmission.Domain;

public interface ICasteMasterRepository
{
    Task<List<CasteMaster>> GetAllAsync(CancellationToken cancellationToken);

    Task<CasteMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(CasteMaster caste, CancellationToken cancellationToken);

    Task Update(CasteMaster caste, CancellationToken cancellationToken);

    Task Delete(CasteMaster caste, CancellationToken cancellationToken);
}