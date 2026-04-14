using SchoolAdmission.Domain.Entities;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Infrastructure.Interfaces;

public interface ISubjectMasterRepository
{
    Task<List<SubjectMaster>> GetAllAsync(CancellationToken cancellationToken);

    Task<SubjectMaster?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task AddAsync(SubjectMaster subject, CancellationToken cancellationToken);

    Task UpdateAsync(SubjectMaster subject, CancellationToken cancellationToken);

    Task DeleteAsync(SubjectMaster subject, CancellationToken cancellationToken);

    Task<bool> IsExistsAsync(string subjectName, OperationType operation, int? subjectId, CancellationToken cancellationToken);
}