using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain.Dtos;

public class StandardMasterQueryDto
{
    public int StandardId { get; set; }
    public string? StandardName { get; set; }
}