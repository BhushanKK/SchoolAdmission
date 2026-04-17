using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.BranchMasters.Commands;

public class CreateBranchMasterCommand : BranchMasterCommandDto, IRequest<ApiResponse<int>>;
