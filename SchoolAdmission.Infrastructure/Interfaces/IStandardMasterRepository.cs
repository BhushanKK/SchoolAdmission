using SchoolAdmission.Domain;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IStandardMasterRepository
{
    Task<List<StandardMaster>> GetAllAsync(CancellationToken cancellationToken);
    Task<StandardMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<int> AddAsync(StandardMaster entity, CancellationToken cancellationToken);
    Task<int> UpdateAsync(StandardMaster entity, CancellationToken cancellationToken);
    Task<int> DeleteAsync(StandardMaster entity, CancellationToken cancellationToken);
    Task<bool> IsExistsAsync(string StandardName, OperationType operation, int? StandardId, CancellationToken cancellationToken);
}
