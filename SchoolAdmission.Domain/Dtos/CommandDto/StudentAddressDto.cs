namespace SchoolAdmission.Domain.Dtos;

public class StudentAddressesDto
{
    public Guid StudentId { get; set; }
    public int? AddressType { get; set; }
    public string? Village { get; set; }
    public string? City { get; set; }
    public string? Taluka { get; set; }
    public string? District { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Pincode { get; set; }
    public string? Landmark { get; set; }
}
