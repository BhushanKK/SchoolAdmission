namespace SchoolAdmission.Domain;

public class SchoolMaster : AuditableEntity
{
    public int SchoolId { get; set; }
    public  required string SchoolName { get; set; }
}