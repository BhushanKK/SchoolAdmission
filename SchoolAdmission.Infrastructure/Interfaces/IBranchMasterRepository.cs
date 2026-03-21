using SchoolAdmission.Domain;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IBranchMasterRepository
{
    Task<List<BranchMaster>> GetAllAsync(CancellationToken cancellationToken);

    Task<BranchMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(BranchMaster branch, CancellationToken cancellationToken);

    Task Update(BranchMaster branch, CancellationToken cancellationToken);

    Task Delete(BranchMaster branch, CancellationToken cancellationToken);

    Task<bool> IsExistsAsync(string BranchName, CancellationToken cancellationToken);
}