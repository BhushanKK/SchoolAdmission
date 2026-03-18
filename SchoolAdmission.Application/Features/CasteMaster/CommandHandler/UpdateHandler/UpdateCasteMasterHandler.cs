using MediatR;
using AutoMapper;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public class UpdateCasteMasterHandler(ICasteMasterRepository repository,IMapper mapper)
    : IRequestHandler<UpdateCasteMasterCommand, bool>
{
    public async Task<bool> Handle(UpdateCasteMasterCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.CasteId, cancellationToken);

        if (entity == null)
            return false;
    
        entity.CasteId = request.CasteId;

        mapper.Map(request, entity);

        await repository.UpdateAsync(entity, cancellationToken);

        return true;
    }
}