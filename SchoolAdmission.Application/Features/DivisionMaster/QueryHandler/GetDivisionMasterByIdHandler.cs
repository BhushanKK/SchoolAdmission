using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.DivisionMasters.Queries;

public class GetDivisionMasterByIdHandler(IDivisionMasterRepository repository)
        : IRequestHandler<GetDivisionMasterByIdQuery, DivisionMaster?>
{
    public async Task<DivisionMaster?> Handle(
        GetDivisionMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await repository.GetByIdWithAsync(request.Id, cancellationToken);
    }
}