using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain;

public class CategoryMaster : AuditableEntity
{
    [JsonIgnore]
    public int CategoryId { get; set; }
    public string? Category { get; set; }
}

