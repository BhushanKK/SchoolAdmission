using SchoolAdmission.Domain;

public interface IReligionMasterRepository
{
    Task<List<ReligionMaster>> GetAllAsync(CancellationToken cancellationToken);
    Task<ReligionMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<int> AddAsync(ReligionMaster entity, CancellationToken cancellationToken);
    Task<int> UpdateAsync(ReligionMaster entity, CancellationToken cancellationToken);
    Task<int> DeleteAsync(int id, CancellationToken cancellationToken);
}