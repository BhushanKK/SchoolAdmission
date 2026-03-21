using MediatR;
//using SchoolAdmission.Application.Interfaces;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.DivisionMasters.Queries;

public class GetDivisionMasterByIdHandler(IDivisionMasterRepository repository)
        : IRequestHandler<GetDivisionMasterByIdQuery, DivisionMasterQueryDto?>
{
    public async Task<DivisionMasterQueryDto?> Handle(
        GetDivisionMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await repository.GetByIdWithAsync(request.Id, cancellationToken);
    }
}