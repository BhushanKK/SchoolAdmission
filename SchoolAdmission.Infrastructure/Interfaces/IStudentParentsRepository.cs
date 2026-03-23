using SchoolAdmission.Domain.Dto;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IStudentParentsRepository
{
    Task<int> SaveStudentParentsAsync(StudentParentsDto command, CancellationToken cancellationToken);
}
