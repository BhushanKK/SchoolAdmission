using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.CommiteMasters.Queries;

public record GetAllCommiteMastersQuery()
    : IRequest<ApiResponse<List<CommiteMasterQueryDto>>>;
