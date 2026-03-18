using MediatR;
using SchoolAdmission.Application.Features.DivisionMasters.Queries;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

public class GetAllDivisionMasterHandler(IDivisionMasterRepository repository) 
    : IRequestHandler<GetAllDivisionMastersQuery, List<DivisionMaster>>
{
    public async Task<List<DivisionMaster>> Handle(
        GetAllDivisionMastersQuery request,
        CancellationToken cancellationToken)
    {
        return await repository.GetAllAsync(cancellationToken);
    }
}