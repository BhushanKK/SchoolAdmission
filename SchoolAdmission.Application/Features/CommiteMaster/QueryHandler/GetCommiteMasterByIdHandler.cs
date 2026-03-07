using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.CommiteMasters.Queries;

public class GetCommiteMasterByIdHandler(ICommiteMasterRepository repository)
    : IRequestHandler<GetCommiteMasterByIdQuery, CommiteMasterQueryDto?>
{
    public async Task<CommiteMasterQueryDto?> Handle(
        GetCommiteMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);

        if (entity == null)
            return null;

        return new CommiteMasterQueryDto
        {
            CommiteeId= entity.CommiteeId,
            CommiteeName = entity.CommiteeName
        };
    }
}
          