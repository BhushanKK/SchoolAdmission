namespace SchoolAdmission.Domain.Dtos;

public class CasteMasterQueryDto
{
    public int CasteId { get; set; }
    public int? CategoryId { get; set; }
    public  required string Caste { get; set; }
    public string? Category { get; set; }
}
