namespace SchoolAdmission.Domain;

public class SchoolMaster
{
public int SchoolId { get; set; }
public  required string SchoolName { get; set; }

public int CommiteeId { get; set; } 
public string? Status { get; set; }


}