namespace SchoolAdmission.Domain.Dtos;

public class StudentFeesDto
{
    public Guid? StudentId { get; set; }

    public decimal? PreviousYearFee { get; set; }

    public decimal? PreviousYearFeePaid { get; set; }

    public bool? IsBusRequired { get; set; }

    public decimal? BusFee { get; set; }

    public decimal? BusFeePaid { get; set; }

    public bool? FeeExemption { get; set; }
}
