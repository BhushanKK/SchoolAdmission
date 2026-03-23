using MediatR;
using AutoMapper;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.FeesStructureDetails.Commands;

public class UpdateFeesStructureHandler(IFeesStructureDetailsRepository repository,IMapper mapper)
    : IRequestHandler<UpdateFeesStructureCommand, bool>
{
    public async Task<bool> Handle(UpdateFeesStructureCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.FeeId, cancellationToken);

        if (entity == null)
            return false;
    
        entity.FeeId = request.FeeId;

        mapper.Map(request, entity);

        await repository.UpdateAsync(entity, cancellationToken);

        return true;
    }
}
