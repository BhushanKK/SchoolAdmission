namespace SchoolAdmission.Domain;

public class ReligionMaster : AuditableEntity
{
    public int ReligionId { get; set; }
    public string? Religion { get; set; }
}