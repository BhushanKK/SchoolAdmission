using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CommiteMasters.Queries;

public class GetAllCommiteMastersHandler(ICommiteMasterRepository repository)
    : IRequestHandler<GetAllCommiteMastersQuery, List<CommiteMaster>>
{
    public async Task<List<CommiteMaster>> Handle(GetAllCommiteMastersQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return data.Select(x => new CommiteMaster
        {
            CommiteeId = x.CommiteeId,
            CommiteeName = x.CommiteeName
        }).ToList();
    }
}