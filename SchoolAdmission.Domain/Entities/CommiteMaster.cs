namespace SchoolAdmission.Domain;

public class CommiteMaster
{
    public int CommiteeId { get; set; }
    public required string CommiteeName { get; set; }
    public bool Status { get; set; }
    public string? Slogan { get; set; } 
}