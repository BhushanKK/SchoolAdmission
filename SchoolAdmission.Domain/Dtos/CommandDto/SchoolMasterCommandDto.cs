using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain.Dtos;
public class SchoolMasterCommandDto
{
    [JsonIgnore]
    public int SchoolId { get; set; }
    public string SchoolName { get; set; } = string.Empty;
    public int CommiteeId { get; set; }
}