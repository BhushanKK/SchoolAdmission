using SchoolAdmission.Domain.Dtos;

public interface IStudentAcademicHistoryRepository
{
    Task<int> SaveStudentAcademicHistoryAsync(StudentAcademicHistoryDto dto, CancellationToken ct);
}