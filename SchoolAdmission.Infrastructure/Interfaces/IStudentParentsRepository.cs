using SchoolAdmission.Domain.Dto;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IStudentParentsRepository
{
    Task<int> SaveStudentParentUsingSpAsync(StudentParentsDto command, CancellationToken cancellationToken);
}