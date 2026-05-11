using MediatR;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.SubjectMasters.Commands;

public record DeleteSubjectMasterCommand(int Id) : IRequest<ApiResponse<bool>>;