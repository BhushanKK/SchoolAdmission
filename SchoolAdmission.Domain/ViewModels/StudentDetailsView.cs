namespace SchoolAdmission.Domain.ViewModels
{
    public class StudentDetailsView
    {
        public Guid StudentId { get; set; }
        public string? RegistrationNo { get; set; }
        public string? SchoolName { get; set; }
        public string? AcademicYearName { get; set; }
        public string? FinancialYearName { get; set; }
        public string? StudentName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string? SaralId { get; set; }
        public string? AadharNo { get; set; }
        public string? Nationality { get; set; }
        public string? MotherTongue { get; set; }
        public string? Religion { get; set; }
        public string? Caste { get; set; }
        public string? IsMinority { get; set; }
        public string? IsHandicapped { get; set; }
        public string? IsBpl { get; set; }
        public string? BPL_Type { get; set; }
        public string? PhotoPath { get; set; }
        public string? BranchName { get; set; }
        public string? PermanentAddress { get; set; }
        public string? CurrentAddress { get; set; }

        public string? PreviousSchool { get; set; }
        public DateTime? SchoolDOE { get; set; }
        public string? Progress { get; set; }
        public string? Behaviour { get; set; }
        public int? PassingYear { get; set; }
        public string? SeatNo { get; set; }
        public decimal? TotalMarks { get; set; }
        public decimal? Percentage { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public int? HandicappedTypeId { get; set; }
        public string? FatherName { get; set; }
        public string? ParentName { get; set; }
        public string? GrandFatherName { get; set; }
        public string? MotherName { get; set; }
        public string? ParentContactNo { get; set; }
        public string? ParentEmail { get; set; }
        public decimal? Income { get; set; }
        public string? Occupation { get; set; }
    }
}
