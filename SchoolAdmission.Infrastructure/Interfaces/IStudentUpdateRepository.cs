using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IStudentUpdateRepository
{
    Task<int> UpdateStudentUsingSpAsync(UpdateStudentDto command, CancellationToken cancellationToken);
}
