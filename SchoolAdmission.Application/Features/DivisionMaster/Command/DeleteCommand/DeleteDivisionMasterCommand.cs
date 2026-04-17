using MediatR;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.DivisionMasters.Commands;

public record DeleteDivisionMasterCommand(int Id) : IRequest<ApiResponse<bool>>;

