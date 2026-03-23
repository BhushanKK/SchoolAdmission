using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain.Dtos;

public class FeesStructureCommandDto
{
    [JsonIgnore]
    public int FeeId { get; set; }

    public string? FeeHeadDescription { get; set; }

    public int StandardId { get; set; }

    public decimal Amount { get; set; }

    public int BranchId { get; set; }
}
