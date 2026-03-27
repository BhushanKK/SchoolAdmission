using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain.Dtos;

public class StudentDocumentDto
{
    public Guid? StudentId { get; set; }

    public int? DocumentType { get; set; }

    public string? DocumentPath { get; set; }
    [JsonIgnore]
    public DateTime UploadedDate { get; set; }

    [JsonIgnore]
    public string? UploadPath { get; set; }
}
