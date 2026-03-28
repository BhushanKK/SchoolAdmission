using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface ICommiteMasterRepository
{
    Task<List<CommiteMasterQueryDto>> GetAllAsync(CancellationToken cancellationToken);

    Task<CommiteMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<CommiteMasterQueryDto?> GetByIdWithCommiteAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(CommiteMaster Commite, CancellationToken cancellationToken);

    Task UpdateAsync(CommiteMaster Commite, CancellationToken cancellationToken);

    Task DeleteAsync(CommiteMaster Commite, CancellationToken cancellationToken);
    
    Task<bool> IsExistsAsync(string CommiteeName, OperationType operation, int? CommiteeId, CancellationToken cancellationToken);
}
