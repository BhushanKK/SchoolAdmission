using MediatR;
using SchoolAdmission.Domain.Dtos;

public class SaveStudentDocumentHandler(IStudentDocumentRepository repo)
    : IRequestHandler<SaveStudentDocumentCommand, int>
{
    public async Task<int> Handle(SaveStudentDocumentCommand request, CancellationToken cancellationToken)
    {
        var dto = new StudentDocumentDto
        {
            DocumentId = request.DocumentId,
            StudentId = request.StudentId,
            DocumentType = request.DocumentType,
            DocumentPath = request.DocumentPath,
            UploadedDate = request.UploadedDate
        };

        return await repo.SaveStudentDocumentAsync(dto, cancellationToken);
    }
}
