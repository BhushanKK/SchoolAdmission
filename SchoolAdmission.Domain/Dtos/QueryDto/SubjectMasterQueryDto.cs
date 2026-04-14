namespace SchoolAdmission.Domain.Dtos;

public class SubjectMasterQueryDto
{
    public int SubjectId { get; set; }
    public int? BranchId { get; set; }
    public int? GroupId { get; set; }
    public string? SubjectName { get; set; }
}