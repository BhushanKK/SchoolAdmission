using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain.Dtos;

public class CasteMasterDto
{
    public int CasteId { get; set; }
    public int? CategoryId { get; set; }
    public string? Caste { get; set; }
    public string? CategoryName { get; set; }
}