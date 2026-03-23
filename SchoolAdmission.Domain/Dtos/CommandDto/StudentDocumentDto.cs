namespace SchoolAdmission.Domain.Dtos;

public class StudentDocumentDto
{
    public long? DocumentId { get; set; }

    public Guid? StudentId { get; set; }

    public int? DocumentType { get; set; }

    public string? DocumentPath { get; set; }

    public DateTime UploadedDate { get; set; }
}
