namespace SchoolAdmission.Infrastructure.Interfaces;

public interface IStudentSubjectStepRepository
{     Task<int> SaveStudentSubjectAsync(Guid studentId, CancellationToken ct);
}