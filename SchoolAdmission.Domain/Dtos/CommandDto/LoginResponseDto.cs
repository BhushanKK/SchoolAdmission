namespace SchoolAdmission.Domain.Dtos.CommandDto;
public class LoginResponseDto
{
    public string AccessToken { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
    public DateTime AccessTokenExpiry { get; set; }
}