using System.Text.Json.Serialization;

namespace SchoolAdmission.Application.Dtos;

public class BranchMastercommandDto
{
    [JsonIgnore]
    public int   BranchId {get; set;}
    public string?  Branch {get; set;}
}

