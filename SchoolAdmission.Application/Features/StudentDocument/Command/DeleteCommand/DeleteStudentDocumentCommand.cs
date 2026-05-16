using MediatR;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentDocuments.Commands;

public record DeleteStudentDocumentCommand(long DocumentId)
    : IRequest<ApiResponse<bool>>;