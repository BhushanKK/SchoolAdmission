namespace SchoolAdmission.Domain.Entities;

public class StudentHealth :AuditableEntity
{
    public long HealthId { get; set; }

    public Guid StudentId { get; set; }

    public decimal? Height { get; set; }

    public decimal? Weight { get; set; }

    public long? HandicappedTypeId { get; set; }
}