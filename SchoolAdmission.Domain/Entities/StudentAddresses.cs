namespace SchoolAdmission.Domain.Entities;

public class StudentAddresses : AuditableEntity
{
    public int AddressId { get; set; }

    public Guid StudentId { get; set; }

    public string? CVillage { get; set; }
    public string? CCity { get; set; }
    public string? CTaluka { get; set; }
    public string? CDistrict { get; set; }
    public string? CState { get; set; }
    public string? CCountry { get; set; }
    public string? CPincode { get; set; }
    public string? CLandmark { get; set; }

    public string? PVillage { get; set; }
    public string? PCity { get; set; }
    public string? PTaluka { get; set; }
    public string? PDistrict { get; set; }
    public string? PState { get; set; }
    public string? PCountry { get; set; }
    public string? PPincode { get; set; }
    public string? PLandmark { get; set; }

    public bool IsSameAddress { get; set; }

}