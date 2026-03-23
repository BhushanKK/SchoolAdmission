using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain.Dtos;

public class CategoryMasterCommandDto
{
    [JsonIgnore]
    public int CategoryId { get; set; }
    public string? Category { get; set; }
}
