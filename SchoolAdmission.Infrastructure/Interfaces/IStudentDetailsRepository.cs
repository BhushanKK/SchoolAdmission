using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IStudentDetailsRepository
{
    Task<StudentDetails?> GetByIdAsync(Guid studentId, CancellationToken cancellationToken);
    Task<int> AddAsync(StudentDetails entity, CancellationToken cancellationToken);
    Task<int> UpdateAsync(StudentDetails entity, CancellationToken cancellationToken);
    Task<int> DeleteAsync(Guid studentId, CancellationToken cancellationToken);
    

}
