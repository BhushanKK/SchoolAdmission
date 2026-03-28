using SchoolAdmission.Domain;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface ISchoolMasterRepository
{
    Task<List<SchoolMaster>> GetAllAsync(CancellationToken cancellationToken);

    Task<SchoolMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);
    
    Task AddAsync(SchoolMaster school, CancellationToken cancellationToken);

    Task UpdateAsync(SchoolMaster school, CancellationToken cancellationToken);

    Task DeleteAsync(SchoolMaster school, CancellationToken cancellationToken);

    Task<bool> IsExistsAsync(string SchoolName, OperationType operation, int? SchoolId, CancellationToken cancellationToken);
}

