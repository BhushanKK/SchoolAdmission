using MediatR;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.SchoolMasters.Commands;

public class DeleteSchoolMasterHandler(
    ISchoolMasterRepository repository
) : IRequestHandler<DeleteSchoolMasterCommand, bool>
{
    public async Task<bool> Handle(DeleteSchoolMasterCommand request,CancellationToken cancellationToken)
    {
        var entity = await repository.GetEntityByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            return false;

        await repository.DeleteAsync(entity,cancellationToken);
        return true;
    }
}