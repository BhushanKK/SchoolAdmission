<<<<<<< HEAD
=======
using System.Text.Json.Serialization;

>>>>>>> 7907a0b3a15df033c9257aa96fdea1b30d1025fc
namespace SchoolAdmission.Domain;

public class CategoryMaster : AuditableEntity
{
<<<<<<< HEAD
    public int categoryId { get; set; }
    public string? Category { get; set; }
}
=======
    [JsonIgnore]
    public int CategoryId { get; set; }
    public string? Category { get; set; }
}

>>>>>>> 7907a0b3a15df033c9257aa96fdea1b30d1025fc
