using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Infrastructure.Interfaces;

public interface IStudentSubjectReportRepository
{
    Task<List<StudentSubjectReport>> GetAllStudentSubjectsAsync(Guid studentId, CancellationToken cancellationToken);
}