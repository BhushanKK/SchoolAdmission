using MediatR;
using SchoolAdmission.Application.Features.DivisionMasters.Queries;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

public class GetAllDivisionMastersHandler(IDivisionMasterRepository repository) 
: IRequestHandler<GetAllDivisionMastersQuery, List<DivisionMaster>>
{
    public async Task<List<DivisionMaster>> Handle(GetAllDivisionMastersQuery request, CancellationToken cancellationToken)
    {
        // Assuming repository has GetAllWithCategoryAsync returning DTOs
        return await repository.GetAllAsync(cancellationToken);
    }
}