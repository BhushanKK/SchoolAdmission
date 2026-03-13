using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

public interface ICommiteMasterRepository
{
    Task<List<CommiteMasterQueryDto>> GetAllAsync(CancellationToken cancellationToken);

    Task<CommiteMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<CommiteMasterQueryDto?> GetByIdWithCommiteAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(CommiteMaster Commite, CancellationToken cancellationToken);

    Task Update(CommiteMaster Commite, CancellationToken cancellationToken);

    Task Delete(CommiteMaster Commite, CancellationToken cancellationToken);

    Task<bool> IsExistsAsync(string CommiteeName, CancellationToken cancellationToken);
}