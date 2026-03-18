using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolAdmission.Infrastructure.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtRepository(IConfiguration config) : IJwtRepository
{
    public async Task<string> GenerateToken(UsersLogin user)
    {
        var key = config["Jwt:Key"]!;

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Email, user.EmailId),
            new Claim(ClaimTypes.Role, user.RoleId.ToString())
        };

        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key));

        var credentials = new SigningCredentials(
            securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    public Task<string> GenerateRefreshToken()
    {
        var randomBytes = new byte[64];

        using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);

        return Task.FromResult(Convert.ToBase64String(randomBytes));
    }
}