using MediatR;
using SchoolAdmission.Application.Features.CommiteMasters.Queries;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Repositories;

public class GetAllCommiteMastersHandler : IRequestHandler<GetAllCommiteMastersQuery, List<CommiteMasterQueryDto>>
{
    private readonly ICommiteMasterRepository _repository;

    public GetAllCommiteMastersHandler(ICommiteMasterRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CommiteMasterQueryDto>> Handle(GetAllCommiteMastersQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
}