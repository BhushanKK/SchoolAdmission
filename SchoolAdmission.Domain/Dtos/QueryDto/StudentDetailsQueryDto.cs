namespace SchoolAdmission.Domain.Dtos;

    public class StudentDetailsQueryDto
    {
        public Guid StudentId { get; set; }
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public string? EmailId { get; set; }
        public string? MobileNo { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
    }

