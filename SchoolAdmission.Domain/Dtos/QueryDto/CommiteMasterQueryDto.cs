namespace SchoolAdmission.Domain.Dtos;

public class CommiteMasterQueryDto
{
    public int CommiteeId { get; set; }
    public string? CommiteeName { get; set; }
    public bool Status { get; set; }
    public string? Slogan { get; set; }
}