namespace SchoolAdmission.Domain;

public class CategoryMaster : AuditableEntity
{
    public int categoryId { get; set; }
    public string? Category { get; set; }
}

