using System.Text.Json.Serialization;

namespace SchoolAdmission.Domain.Dtos;

    public class StudentDetailsQueryDto
    {
        [JsonIgnore]
        public Guid StudentId { get; set; }
        public long? RegistrationNo { get; set; }
        public long? SchoolId { get; set; }
        public long? AcademicYearId { get; set; }
        public long? FinancialYearId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string? SaralId { get; set; }
        public string? AadharNo { get; set; }
        public string? Nationality { get; set; }
        public string? MotherTongue { get; set; }
        public long? ReligionId { get; set; }
        public long? CasteId { get; set; }
        public long? CategoryId { get; set; }
        public bool? IsMinority { get; set; }
        public bool? IsHandicapped { get; set; }
        public bool? IsBpl { get; set; }
        public string? BPL_Type { get; set; }
        public string? Photo { get; set; }
        public string? EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public string? ModifyBy { get; set; }
        public long? BranchId { get ; set ; }
    }

