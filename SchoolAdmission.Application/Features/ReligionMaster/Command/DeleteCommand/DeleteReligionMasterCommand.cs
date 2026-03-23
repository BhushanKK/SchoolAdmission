using MediatR;

namespace SchoolAdmission.Application.Features.ReligionMasters.Commands;

public record DeleteReligionMasterCommand(int Id) : IRequest<ApiResponse<bool>>;
