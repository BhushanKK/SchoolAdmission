namespace SchoolAdmission.Domain;

public class CommiteMaster : AuditableEntity
{
    public int CommiteeId { get; set; }
    public  string? CommiteeName { get; set; }
    public bool Status { get; set; }
    public string? Slogan { get; set; } 
}