namespace SchoolAdmission.Domain;

public class CasteMaster : AuditableEntity
{
    public int CasteId { get; set; }
    public int? CategoryId { get; set; }
    public string? Caste { get; set; }
}
