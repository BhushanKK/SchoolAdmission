namespace SchoolAdmission.Domain;

public class SchoolMaster : AuditableEntity
{
    public int SchoolId { get; set; }
    public string? SchoolName { get; set; }
}
