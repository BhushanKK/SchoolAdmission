using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CommiteMasters.Queries;

public class GetCommiteMasterByIdHandler(ICommiteMasterRepository repository)
    : IRequestHandler<GetCommiteMasterByIdQuery, CommiteMaster?>
{
    public async Task<CommiteMaster?> Handle(
        GetCommiteMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);

        if (entity == null)
            return null;

        return new CommiteMaster
        {
            CommiteeId= entity.CommiteeId,
            CommiteeName = entity.CommiteeName
        };
    }
}
          