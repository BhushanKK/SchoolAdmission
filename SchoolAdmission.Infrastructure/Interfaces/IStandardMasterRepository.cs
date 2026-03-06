using SchoolAdmission.Domain;

public interface IStandardMasterRepository
{
    Task<List<StandardMaster>> GetAllAsync(CancellationToken cancellationToken);
    Task<StandardMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<int> AddAsync(StandardMaster entity, CancellationToken cancellationToken);
    Task<int> UpdateAsync(StandardMaster entity, CancellationToken cancellationToken);
    Task<int> DeleteAsync(int id, CancellationToken cancellationToken);
}