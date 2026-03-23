namespace SchoolAdmission.Domain;
public class FeesStructureDetails
{
    public int FeeId { get; set; }

    public string? FeeHeadDescription { get; set; }

    public int StandardId { get; set; }

    public decimal Amount { get; set; }

    public int BranchId { get; set; }
}
