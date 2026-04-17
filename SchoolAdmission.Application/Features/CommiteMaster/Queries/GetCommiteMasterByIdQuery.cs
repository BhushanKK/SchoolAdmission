using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.CommiteMasters.Queries;

public record GetCommiteMasterByIdQuery(int Id)
    : IRequest<ApiResponse<CommiteMasterQueryDto?>>;
