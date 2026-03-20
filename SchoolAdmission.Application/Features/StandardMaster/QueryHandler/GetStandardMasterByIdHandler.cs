using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.StandardMasters.Queries;

public class GetStandardMasterByIdHandler(IStandardMasterRepository repository)
    : IRequestHandler<GetStandardMasterByIdQuery, StandardMaster?>
{
    public async Task<StandardMaster?> Handle(GetStandardMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);

        if (entity == null)
            return null;

        return new StandardMaster
        {
            StandardId= entity.StandardId,
            StandardName = entity.StandardName
        };
    }
}
          