namespace SchoolAdmission.Domain.Dtos;

public class SubjectMasterQueryDto
{
    public int SubjectId { get; set; }
    public int? BranchId { get; set; }
    public int? GroupId { get; set; }
    public string? SubjectName { get; set; }
}

public class GroupedSubjectsDto
{
    public int BranchId { get; set; }
    public Dictionary<int, List<SubjectItemDto>> Groups { get; set; } = new();
}

public class SubjectItemDto
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; } = string.Empty;
}