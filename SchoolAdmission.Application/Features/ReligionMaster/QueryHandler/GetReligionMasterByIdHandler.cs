using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.Religions.Queries;

public class GetReligionMasterByIdHandler(IReligionMasterRepository repository)
    : IRequestHandler<GetReligionMasterByIdQuery, ReligionMaster?>
{
    public async Task<ReligionMaster?> Handle(GetReligionMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            return null;

        return new ReligionMaster
        {
            ReligionId = entity.ReligionId,
            Religion = entity.Religion
        };
    }
}
