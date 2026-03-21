using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain.Entities;
public class UpdateStudentDto
{
    [JsonIgnore]
    public Guid StudentId { get; set; }
    public long? RegistrationNo { get; set; }
    public int? SchoolId { get; set; }
    public int? AcademicYearId { get; set; }
    public int? FinancialYearId { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public bool Gender { get; set; }
    public DateTime DOB { get; set; }
    public string? SaralId { get; set; }
    public string? AadharNo { get; set; }
    public string? Nationality { get; set; }
    public string? MotherTongue { get; set; }
    public int? ReligionId { get; set; }
    public int? CasteId { get; set; }
    public int? CategoryId { get; set; }
    public bool IsMinority { get; set; }
    public bool IsHandicapped { get; set; }
    public bool IsBpl { get; set; }
    public int? BPL_Type { get; set; }
    public string? Photo { get; set; }
    public int? ModifyBy { get; set; }
    public int? BranchId { get; set; }
}