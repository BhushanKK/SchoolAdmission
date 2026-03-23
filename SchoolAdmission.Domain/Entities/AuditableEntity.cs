using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain;

public class AuditableEntity
{
    [JsonIgnore]
    public string? EntryBy { get; set; }
     [JsonIgnore]
    public DateTime? EntryDate { get; set; }
     [JsonIgnore]
    public string? ModifyBy { get; set; }
    [JsonIgnore]
    public DateTime? ModifiedDate { get; set; }
}
