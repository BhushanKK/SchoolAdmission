using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.CommiteMasters.Commands;

public interface ICreateCommiteMasterHandler
{
    Task<int> Handle(CreateCommiteMasterCommand request, CancellationToken cancellationToken);
}

public class CreateCommiteMasterHandler(IMapper mapper,
    ApplicationDbContext context) : IRequestHandler<CreateCommiteMasterCommand, int>, ICreateCommiteMasterHandler
{
    public async Task<int> Handle(CreateCommiteMasterCommand request, CancellationToken cancellationToken)
    {
        var commiteMaster = mapper.Map<CommiteMaster>(request);
        await context.CommiteMasters.AddAsync(commiteMaster, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return commiteMaster.CommiteeId;
    }
}