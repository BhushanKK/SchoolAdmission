using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain;

public class AuditableEntity
{
    [JsonIgnore]
    public int? EntryBy { get; set; }
     [JsonIgnore]
    public DateTime? EntryDate { get; set; }
     [JsonIgnore]
    public int? ModifyBy { get; set; }
    [JsonIgnore]
    public DateTime? ModifiedDate { get; set; }
}