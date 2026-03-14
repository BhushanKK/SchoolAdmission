using MediatR;
using AutoMapper;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.Religions.Commands;

public class UpdateReligionMasterHandler(IReligionMasterRepository repository,IMapper mapper)
    : IRequestHandler<UpdateReligionMasterCommand, bool>
{
    public async Task<bool> Handle(UpdateReligionMasterCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.ReligionId, cancellationToken);

        if (entity == null)
            return false;
    
        entity.ReligionId = request.ReligionId;

        mapper.Map(request, entity);

        await repository.UpdateAsync(entity, cancellationToken);

        return true;
    }
}