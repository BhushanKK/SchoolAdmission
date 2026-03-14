namespace SchoolAdmission.Domain.Dtos.CommandDto;
public class LoginRequestDto
{
    public string UserName { get; set; } = default!;   // email or mobile
    public string Password { get; set; } = default!;
}