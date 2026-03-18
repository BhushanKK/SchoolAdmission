using MediatR;
using AutoMapper;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CommiteMasters.Commands;

public class UpdateCommiteMasterHandler(ICommiteMasterRepository repository,IMapper mapper)
    : IRequestHandler<UpdateCommiteMasterCommand, bool>
{
    public async Task<bool> Handle(UpdateCommiteMasterCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.CommiteeId, cancellationToken);

        if (entity == null)
            return false;
    
        entity.CommiteeId = request.CommiteeId;

        mapper.Map(request, entity);

        await repository.UpdateAsync(entity, cancellationToken);

        return true;
    }
}