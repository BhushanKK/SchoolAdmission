namespace SchoolAdmission.Domain;

public class BranchMaster : AuditableEntity
{
    public int BranchId { get; set; }
    public string? BranchName { get; set; }
}

