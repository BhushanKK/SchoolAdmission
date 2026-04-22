using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IStudentAcademicHistoryRepository
{
    Task<StudentAcademicHistory?> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken);
    Task<int> SaveStudentAcademicHistoryAsync(StudentAcademicHistoryDto dto, CancellationToken ct);
}
