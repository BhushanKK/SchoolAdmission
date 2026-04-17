using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.StudentDocuments.Commands;
public class SaveStudentDocumentCommand : StudentDocumentDto, IRequest<ApiResponse<int>>
{
    public IFormFile? File { get; set; }
}

