using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain.Dto;

public class SubjectMasterCommandDto
{
    [JsonIgnore]
    public int SubjectId { get; set; }
    public int BranchId { get; set; }
    public int GroupId { get; set; }
    public string? SubjectName { get; set; }
    
}