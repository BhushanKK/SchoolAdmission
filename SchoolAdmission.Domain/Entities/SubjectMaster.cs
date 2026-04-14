namespace SchoolAdmission.Domain.Entities;

public class SubjectMaster : AuditableEntity
{
    public int SubjectId { get; set; }   

    public int? BranchId { get; set; }   
    public int? GroupId { get; set; }   

    public string SubjectName { get; set; } = string.Empty;  
}