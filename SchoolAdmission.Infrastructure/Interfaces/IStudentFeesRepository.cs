using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Infrastructure.Interfaces;

public interface IStudentFeesRepository
{
    Task<int> SaveStudentFeesAsync(StudentFeesDto entity, CancellationToken cancellationToken);
}
