using MediatR;

namespace SchoolAdmission.Application.Features.BranchMasters.Commands;

public record DeleteSubjectMasterCommand(int Id) : IRequest<ApiResponse<bool>>;
