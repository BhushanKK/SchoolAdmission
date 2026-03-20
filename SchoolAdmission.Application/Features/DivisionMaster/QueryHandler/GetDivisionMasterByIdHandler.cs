using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.DivisionMasters.Queries;

public class GetDivisionMasterByIdHandler(IDivisionMasterRepository repository)
    : IRequestHandler<GetDivisionMasterByIdQuery, DivisionMaster?>
{
    public async Task<DivisionMaster?> Handle(GetDivisionMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            return null;

        return new DivisionMaster
        {
            DivisionId = entity.DivisionId,
            DivisionName = entity.DivisionName
        };
    }
}