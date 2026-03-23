namespace SchoolAdmission.Domain;

public class DivisionMaster :AuditableEntity
{
    public int DivisionId { get; set; }
    public string? DivisionName { get; set; }
}
