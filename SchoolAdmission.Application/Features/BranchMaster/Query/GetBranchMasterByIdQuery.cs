using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.BranchMasters.Queries;

public record GetBranchMasterByIdQuery(int Id)
    : IRequest<ApiResponse<BranchMasterQueryDto?>>;
