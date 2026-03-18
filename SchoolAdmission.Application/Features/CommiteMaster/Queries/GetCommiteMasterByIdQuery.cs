using MediatR;
using SchoolAdmission.Domain;

namespace SchoolAdmission.Application.Features.CommiteMasters.Queries;
public record GetCommiteMasterByIdQuery(int Id)
    : IRequest<CommiteMaster?>;