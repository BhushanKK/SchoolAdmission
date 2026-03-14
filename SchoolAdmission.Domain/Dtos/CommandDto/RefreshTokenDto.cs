namespace SchoolAdmission.Domain.Entities;

public class RefreshTokenDto
{
    public Guid UserId { get; set; }
    public string RefreshToken { get; set; } = default!;
}