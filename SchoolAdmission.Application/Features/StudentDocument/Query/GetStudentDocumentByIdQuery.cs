using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentDocument.Queries;

public record GetStudentDocumentByStudentIdQuery(Guid StudentId)
    : IRequest<ApiResponse<List<StudentDocumentQueryDto?>>>;