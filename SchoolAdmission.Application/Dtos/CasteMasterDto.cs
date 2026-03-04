using System.Text.Json.Serialization;

namespace SchoolAdmission.Application.Dtos;

public class CasteMasterDto
{
    [JsonIgnore]
    public int CasteId { get; set; }
    public int? CategoryId { get; set; }
    public string? Caste { get; set; }
}