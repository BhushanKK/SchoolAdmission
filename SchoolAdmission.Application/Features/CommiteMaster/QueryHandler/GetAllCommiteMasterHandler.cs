using MediatR;
using SchoolAdmission.Application.Features.CommiteMasters.Queries;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Interfaces;

public class GetAllCommiteMastersHandler(ICommiteMasterRepository repository) : IRequestHandler<GetAllCommiteMastersQuery, List<CommiteMasterQueryDto>>
{
    public async Task<List<CommiteMasterQueryDto>> Handle(GetAllCommiteMastersQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllAsync(cancellationToken);
    }
}