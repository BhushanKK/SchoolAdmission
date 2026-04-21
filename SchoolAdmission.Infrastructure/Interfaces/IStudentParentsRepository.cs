using SchoolAdmission.Domain.Dto;
using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IStudentParentsRepository
{
    Task<StudentParents?> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken);
    Task<int> SaveStudentParentsAsync(StudentParentsDto command, CancellationToken cancellationToken);
}
