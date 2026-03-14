using MediatR;
using AutoMapper;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.StandardMasters.Commands;

public class UpdateStandardMasterHandler(IStandardMasterRepository repository,IMapper mapper)
    : IRequestHandler<UpdateStandardMasterCommand, bool>
{
    public async Task<bool> Handle(UpdateStandardMasterCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.StandardId, cancellationToken);

        if (entity == null)
            return false;
    
        entity.StandardId = request.StandardId;

        mapper.Map(request, entity);

        await repository.UpdateAsync(entity, cancellationToken);

        return true;
    }
}