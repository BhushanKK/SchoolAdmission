using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentDocuments.Commands;
public class SaveStudentDocumentCommand : StudentDocumentDto, IRequest<ApiResponse<int>>
{
    public IFormFile? File { get; set; }
}

