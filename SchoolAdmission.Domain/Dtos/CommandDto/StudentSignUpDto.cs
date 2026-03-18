using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain.Entities;

public class StudentSignUpDto
{
    [JsonIgnore]
    public Guid UserId { get; set; }
    [JsonIgnore]
    public int RoleId { get; set; }
    [JsonIgnore]
    public Guid? StudentId { get; set; }
    public string? EmailId { get; set; }
    public string? MobileNo { get; set; }
    public string? PasswordHash { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
}