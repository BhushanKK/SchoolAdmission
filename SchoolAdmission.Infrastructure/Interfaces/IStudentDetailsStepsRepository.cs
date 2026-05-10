using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IStudentDetailsStepsRepository
{
    Task<int> AddAsync(StudentDetailsStep entity, CancellationToken cancellationToken); 
    Task<int> UpdateAsync(Guid studentId, StudentDetailsStep entity, CancellationToken cancellationToken); 
}
