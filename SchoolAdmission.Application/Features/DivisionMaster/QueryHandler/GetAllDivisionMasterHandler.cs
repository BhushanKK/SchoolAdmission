using MediatR;
using SchoolAdmission.Application.Features.DivisionMasters.Queries;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Interfaces;

public class GetAllDivisionMastersHandler(IDivisionMasterRepository repository) : IRequestHandler<GetAllDivisionMastersQuery, List<DivisionMasterQueryDto>>
{
    public async Task<List<DivisionMasterQueryDto>> Handle(GetAllDivisionMastersQuery request, CancellationToken cancellationToken)
    {
        // Assuming repository has GetAllWithCategoryAsync returning DTOs
        return await repository.GetAllAsync(cancellationToken);
    }
}