using MediatR;
using SchoolAdmission.Application.Features.CommiteMasters.Queries;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

public class GetAllCommiteMastersHandler(ICommiteMasterRepository repository) 
: IRequestHandler<GetAllCommiteMastersQuery, List<CommiteMaster>>
{
    public async Task<List<CommiteMaster>> Handle(GetAllCommiteMastersQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllAsync(cancellationToken);
    }
}