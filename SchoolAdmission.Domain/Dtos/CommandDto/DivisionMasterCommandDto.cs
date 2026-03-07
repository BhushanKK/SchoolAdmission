using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain.Dtos;

public class DivisionMasterCommandDto
{
    [JsonIgnore]
    public int DivisionId { get; set; }
    public string? DivisionName { get; set; }
}