using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface ICommiteMasterRepository
{
    Task<List<CommiteMasterQueryDto>> GetAllAsync(CancellationToken cancellationToken);

    Task<CommiteMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<CommiteMasterQueryDto?> GetByIdWithCommiteAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(CommiteMaster Commite, CancellationToken cancellationToken);

    Task UpdateAsync(CommiteMaster Commite, CancellationToken cancellationToken);

    Task DeleteAsync(CommiteMaster Commite, CancellationToken cancellationToken);

    Task<bool> IsExistsAsync(string CommiteeName, CancellationToken cancellationToken);
}