namespace SchoolAdmission.Domain.Entities;

public class StudentSignUpDto
{
    public string FirstName { get; set; } = default!;
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string MobileNo { get; set; } = default!;
    public string EmailId { get; set; } = default!;
    public string Password { get; set; } = default!;
}