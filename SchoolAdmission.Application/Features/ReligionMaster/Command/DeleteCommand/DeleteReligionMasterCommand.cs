using MediatR;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.ReligionMasters.Commands;

public record DeleteReligionMasterCommand(int Id) : IRequest<ApiResponse<bool>>;
