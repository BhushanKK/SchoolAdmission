namespace SchoolAdmission.Domain.Entities;
public class Administration
{
    public int AdminId { get; set; }

    public string MobileNo { get; set; } = default!;

    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }

    public string FirstName { get; set; } = default!;

    public string? LastName { get; set; }
}