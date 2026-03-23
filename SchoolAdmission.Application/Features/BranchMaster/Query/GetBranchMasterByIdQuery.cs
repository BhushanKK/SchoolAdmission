using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.BranchMasters.Queries;

public record GetBranchMasterByIdQuery(int Id)
    : IRequest<ApiResponse<BranchMasterQueryDto?>>;
