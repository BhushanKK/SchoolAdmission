namespace SchoolAdmission.Domain.Entities;

public class StudentFees : AuditableEntity
{
    public long FeeId { get; set; }

    public Guid StudentId { get; set; }

    public decimal? PreviousYearFee { get; set; }

    public decimal? PreviousYearFeePaid { get; set; }

    public bool? IsBusRequired { get; set; }

    public decimal? BusFee { get; set; }

    public decimal? BusFeePaid { get; set; }

    public bool? FeeExemption { get; set; }
}