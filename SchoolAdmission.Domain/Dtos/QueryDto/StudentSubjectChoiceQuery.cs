namespace SchoolAdmission.Domain.Dtos;
public class StudentSubjectChoiceQueryDto
{
    public int ChoiceId { get; set; }
    public int SubjectId { get; set; }
    public int BranchId { get; set; }
    public int GroupId { get; set; }
    public Guid StudentId { get; set; }
}