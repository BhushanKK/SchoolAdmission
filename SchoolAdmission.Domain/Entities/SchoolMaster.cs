namespace SchoolAdmission.Domain;

public class SchoolMaster : AuditableEntity
{
    public int SchoolId { get; set; }
    public string? SchoolName { get; set; }
    public int CommiteeId { get; set; }
    public string? Status { get; set; }
    public string? LogoPath { get; set; }
}
