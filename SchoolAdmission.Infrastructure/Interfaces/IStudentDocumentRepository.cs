using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Infrastructure.Interfaces;
public interface IStudentDocumentRepository
{
    Task<int> SaveStudentDocumentAsync(StudentDocumentDto dto, CancellationToken cancellationToken);
}
