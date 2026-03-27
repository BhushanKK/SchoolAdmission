namespace SchoolAdmission.Domain.Dtos;

public class StudentHealthDto
{
    public Guid StudentId { get; set; }

    public decimal? Height { get; set; }

    public decimal? Weight { get; set; }

    public int? HandicappedTypeId { get; set; }
}

