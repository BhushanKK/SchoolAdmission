using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Infrastructure.Interfaces;

public interface IStudentRepository
{
    Task AddAsync(StudentDetails student,CancellationToken cancellationToken);

    Task<StudentDetails?> GetByIdAsync(Guid studentId,CancellationToken cancellationToken);
}