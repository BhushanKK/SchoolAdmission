using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Infrastructure.Interfaces;

public interface IStudentHealthRepository
{
    Task<StudentHealth?> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken);
    Task<int> SaveStudentHealthAsync(StudentHealthDto entity, CancellationToken cancellationToken);
}
