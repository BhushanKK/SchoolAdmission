using MediatR;

namespace SchoolAdmission.Application.Features.SchoolMasters.Commands;

public record DeleteSchoolMasterCommand(int Id) : IRequest<ApiResponse<bool>>;
