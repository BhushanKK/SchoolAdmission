using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.Religions.Queries;

public class GetReligionMasterByIdHandler(IReligionMasterRepository repository)
    : IRequestHandler<GetReligionMasterByIdQuery, ReligionMasterQueryDto?>
{
    public async Task<ReligionMasterQueryDto?> Handle(
        GetReligionMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            return null;

        return new ReligionMasterQueryDto
        {
            ReligionId = entity.ReligionId,
            Religion = entity.Religion
        };
    }
}
