namespace SchoolAdmission.Domain.Dtos;

public class StudentAcademicHistoryDto
{
    public long? AcademicHistoryId { get; set; }
    public Guid? StudentId { get; set; }
    public string? PreviousSchool { get; set; }
    public DateTime? SchoolDOE { get; set; }
    public string? Progress { get; set; }
    public string? Behaviour { get; set; }
    public int? PassingYear { get; set; }
    public string? SeatNo { get; set; }
    public int? TotalMarks { get; set; }
    public decimal? Percentage { get; set; }
}
