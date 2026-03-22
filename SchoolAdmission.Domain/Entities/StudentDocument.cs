namespace SchoolAdmission.Domain.Entities;

public class StudentDocument : AuditableEntity
{
    public long DocumentId { get; set; }              

    public Guid StudentId { get; set; }               

    public int? DocumentType { get; set; }            

    public string? DocumentPath { get; set; }         

    public DateTime UploadedDate { get; set; }        
}