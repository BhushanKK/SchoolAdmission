namespace SchoolAdmission.Domain;

public class AuditableEntity
{
    public int? EntryBy { get; set; }
    public DateTime? EntryDate { get; set; }
    public int? ModifyBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
}