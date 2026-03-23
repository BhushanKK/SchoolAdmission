using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain.Dtos;

public class BranchMasterCommandDto
{
    [JsonIgnore]
    public int   BranchId {get; set;}
    public string?  BranchName {get; set;}
}


