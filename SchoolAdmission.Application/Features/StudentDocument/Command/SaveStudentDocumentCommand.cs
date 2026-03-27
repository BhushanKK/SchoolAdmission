using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolAdmission.Domain.Dtos;

public class SaveStudentDocumentCommand : StudentDocumentDto, IRequest<ApiResponse<int>>
{
    public IFormFile? File { get; set; }
}

