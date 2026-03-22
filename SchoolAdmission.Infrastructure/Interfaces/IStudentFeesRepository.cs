using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Infrastructure.Interfaces;

public interface IStudentFeesRepository
{
    Task<int> SaveStudentFeesAsync(StudentFeesDto entity, CancellationToken cancellationToken);
}