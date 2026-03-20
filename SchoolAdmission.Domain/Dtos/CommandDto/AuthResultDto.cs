using System.Text.Json.Serialization;
namespace SchoolAdmission.Domain.Dtos.CommandDto;
public class AuthResultDto
{
    public Guid UserId { get; set; }
    public string AccessToken { get; set; } = default!;
    public DateTime AccessTokenExpiry { get; set; }

    public string RefreshToken { get; set; } = default!;
    public DateTime RefreshTokenExpiry { get; set; }

    public string Role { get; set; } = default!;
}