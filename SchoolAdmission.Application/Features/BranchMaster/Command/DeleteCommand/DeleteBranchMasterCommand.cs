using MediatR;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.BranchMasters.Commands;

public record DeleteBranchMasterCommand(int Id) : IRequest<ApiResponse<bool>>;
