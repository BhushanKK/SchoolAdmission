using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Dtos;

public interface ISchoolMasterRepository
{
    Task<List<SchoolMasterQueryDto>> GetAllAsync(CancellationToken cancellationToken);

    Task<SchoolMasterQueryDto?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<SchoolMaster?> GetEntityByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(SchoolMaster school, CancellationToken cancellationToken);

    Task Update(SchoolMaster school, CancellationToken cancellationToken);

    Task Delete(SchoolMaster school, CancellationToken cancellationToken);

    Task<bool> IsExistsAsync(string SchoolName, CancellationToken cancellationToken);
}