using MediatR;
using AutoMapper;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.FeesStructureDetails.Commands;

public class UpdateFeesStructureHandler(IFeesStructureDetailRepository repository,IMapper mapper)
    : IRequestHandler<UpdateFeesStructureDetailCommand, bool>
{
    public async Task<bool> Handle(UpdateFeesStructureDetailCommand request, CancellationToken cancellationToken)
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