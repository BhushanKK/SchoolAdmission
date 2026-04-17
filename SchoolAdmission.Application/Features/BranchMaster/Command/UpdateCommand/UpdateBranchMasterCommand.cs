using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.BranchMasters.Commands;

public class UpdateBranchMasterCommand : BranchMasterCommandDto, IRequest<ApiResponse<bool>>;
