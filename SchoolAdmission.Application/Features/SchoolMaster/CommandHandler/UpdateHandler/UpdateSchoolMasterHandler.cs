using MediatR;
using AutoMapper;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.SchoolMasters.Commands;

public class UpdateSchoolMasterCommandHandler(ISchoolMasterRepository repository,IMapper mapper)
: IRequestHandler<UpdateSchoolMasterCommand, bool>
{
    public async Task<bool> Handle(
        UpdateSchoolMasterCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetEntityByIdAsync(request.SchoolId, cancellationToken);

        if (entity == null)
            return false;

        mapper.Map(request, entity);

        await repository.UpdateAsync(entity, cancellationToken);
        return true;
    }
}