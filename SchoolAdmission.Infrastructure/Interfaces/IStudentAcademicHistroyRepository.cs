using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IStudentAcademicHistoryRepository
{

    Task<int> SaveStudentAcademicHistoryAsync(StudentAcademicHistoryDto dto, CancellationToken ct);
}
