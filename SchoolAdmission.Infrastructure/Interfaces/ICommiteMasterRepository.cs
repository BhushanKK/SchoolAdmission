using SchoolAdmission.Domain;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface ICommiteMasterRepository
{
    Task<List<CommiteMaster>> GetAllAsync(CancellationToken cancellationToken);

    Task<CommiteMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(CommiteMaster Commite, CancellationToken cancellationToken);

    Task UpdateAsync(CommiteMaster Commite, CancellationToken cancellationToken);

    Task DeleteAsync(CommiteMaster Commite, CancellationToken cancellationToken);

    Task<bool> IsExistsAsync(string CommiteeName, CancellationToken cancellationToken);
}