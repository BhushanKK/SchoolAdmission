using SchoolAdmission.Domain.Entities;

public class UsersLogin
{
    public Guid UserId { get; set; }

    public string EmailId { get; set; } = default!;

    public string MobileNo { get; set; } = default!;

    public string PasswordHash { get; set; } = default!;

    public int RoleId { get; set; }

    public Guid? StudentId { get; set; }

    public int? AdminId { get; set; }

    public bool IsActive { get; set; }

    public bool IsLocked { get; set; }

    public int FailedLoginAttempts { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public DateTime? PasswordChangedDate { get; set; }

    public string? AccessToken { get; set; }

    public DateTime? AccessTokenExpiry { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiry { get; set; }

    public DateTime CreatedDate { get; set; }

    public string Role { get; set; } = default!;

    public StudentDetails? Student { get; set; }

    public Administration? Admin { get; set; }
}