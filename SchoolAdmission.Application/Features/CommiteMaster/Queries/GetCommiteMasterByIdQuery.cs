using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.CommiteMasters.Queries;

public record GetCommiteMasterByIdQuery(int Id)
    : IRequest<ApiResponse<CommiteMasterQueryDto?>>;
