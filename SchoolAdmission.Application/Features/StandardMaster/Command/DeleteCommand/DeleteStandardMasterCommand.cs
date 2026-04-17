using MediatR;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StandardMasters.Commands;

public record DeleteStandardMasterCommand(int Id) : IRequest<ApiResponse<bool>>;
