namespace SchoolAdmission.Domain.Dtos;

public class CasteMasterQueryDto
{
    public int CasteId { get; set; }
    public int? CategoryId { get; set; }
    public string? Caste { get; set; }
    public string? CategoryName { get; set; }
}