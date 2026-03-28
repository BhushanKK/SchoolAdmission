using SchoolAdmission.Domain;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IBranchMasterRepository
{
    Task<List<BranchMaster>> GetAllAsync(CancellationToken cancellationToken);

    Task<BranchMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(BranchMaster branch, CancellationToken cancellationToken);

    Task UpdateAsync(BranchMaster branch, CancellationToken cancellationToken);

    Task DeleteAsync(BranchMaster branch, CancellationToken cancellationToken);

    Task<bool> IsExistsAsync(string BranchName, OperationType operation, int? BranchId, CancellationToken cancellationToken);
}
