using MediatR;
using AutoMapper;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.DivisionMasters.Commands;

public class UpdateDivisionMasterHandler(IDivisionMasterRepository repository,IMapper mapper)
    : IRequestHandler<UpdateDivisionMasterCommand, bool>
{
    public async Task<bool> Handle(UpdateDivisionMasterCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.DivisionId, cancellationToken);

        if (entity == null)
            return false;
    
        entity.DivisionId = request.DivisionId;

        mapper.Map(request, entity);

        await repository.Update(entity, cancellationToken);

        return true;
    }
}