using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IStudentDocumentRepository
{
    Task<List<StudentDocument>> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken);
    Task<int> SaveStudentDocumentAsync(StudentDocumentDto dto, CancellationToken cancellationToken);
}
