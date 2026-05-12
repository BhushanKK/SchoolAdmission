using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain.Entities;

public class StudentSubjectChoice
{
    [JsonIgnore]
    public int ChoiceId { get; set; }
    public int BranchId { get; set; }
    public int SubjectId { get; set; }
    public int GroupId { get; set; }
    public Guid StudentId { get; set; }
}