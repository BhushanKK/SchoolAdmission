using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain.Dtos;

public class CategoryMasterDto
{
    [JsonIgnore]
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
}