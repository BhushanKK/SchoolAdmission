namespace SchoolAdmission.Domain;

public class CasteMaster : AuditableEntity
{
    public int CasteId { get; set; }
    public int? CategoryId { get; set; }
    public required string Caste { get; set; }
}
