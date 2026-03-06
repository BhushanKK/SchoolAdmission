namespace SchoolAdmission.Domain
{
    public class StandardMaster : AuditableEntity
    {
        public int StandardId { get; set; }
        public string? StandardName { get; set; }
    }
}