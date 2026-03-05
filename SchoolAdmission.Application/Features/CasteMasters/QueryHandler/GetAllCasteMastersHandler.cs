using MediatR;
using SchoolAdmission.Application.Features.CasteMasters.Queries;
using SchoolAdmission.Domain.Dtos;

public class GetAllCasteMastersHandler(ICasteMasterRepository repository) : IRequestHandler<GetAllCasteMastersQuery, List<CasteMasterDto>>
{
    public async Task<List<CasteMasterDto>> Handle(GetAllCasteMastersQuery request, CancellationToken cancellationToken)
    {
        // Assuming repository has GetAllWithCategoryAsync returning DTOs
        return await repository.GetAllAsync(cancellationToken);
    }
}