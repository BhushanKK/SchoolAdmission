namespace SchoolAdmission.Domain.Entities;

public class StudentParents : AuditableEntity
{
    public long ParentId { get; set; }

    public Guid StudentId { get; set; }

    public string? FatherName { get; set; }

    public string? MotherName { get; set; }

    public string? GrandFatherName { get; set; }

    public string? ParentName { get; set; }

    public string? ContactNo { get; set; }

    public string? EmailId { get; set; }

    public decimal? Income { get; set; }

    public string? Occupation { get; set; }

    public StudentDetails? Student { get; set; }
}
