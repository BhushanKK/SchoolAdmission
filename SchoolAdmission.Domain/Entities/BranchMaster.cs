namespace SchoolAdmission.Domain;

public class BranchMaster : AuditableEntity
{
    public int branchId { get; set; }
    public string? Branch { get; set; }
}

