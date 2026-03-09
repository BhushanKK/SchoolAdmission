using MediatR;

namespace SchoolAdmission.Application.Features.SchoolMasters.Commands;

public class DeleteSchoolMasterCommandHandler(
    ISchoolMasterRepository repository
) : IRequestHandler<DeleteSchoolMasterCommand, bool>
{
    public async Task<bool> Handle(DeleteSchoolMasterCommand request,CancellationToken cancellationToken)
    {
        var entity = await repository.GetEntityByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            return false;

        await repository.Delete(entity,cancellationToken);
        return true;
    }
}