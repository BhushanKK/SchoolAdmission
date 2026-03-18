using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.CommiteMasters.Queries;

public record GetAllCommiteMastersQuery()
    : IRequest<List<CommiteMaster>>;