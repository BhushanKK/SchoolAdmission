using SchoolAdmission.Domain.Dtos;

public interface IStudentDocumentRepository
{
    Task<int> SaveStudentDocumentAsync(StudentDocumentDto dto, CancellationToken cancellationToken);
}