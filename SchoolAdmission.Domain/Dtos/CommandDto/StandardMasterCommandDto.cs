using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain.Dtos;
public class StandardMasterCommandDto
{
    [JsonIgnore]
    public int StandardId { get; set; }
    public string StandardName { get; set; } = string.Empty;
}