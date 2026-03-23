using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Infrastructure.Interfaces;

public interface IStudentHealthRepository
{
    Task<int> SaveStudentHealthAsync(StudentHealthDto entity, CancellationToken cancellationToken);
}
