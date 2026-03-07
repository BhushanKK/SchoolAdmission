using MediatR;
using SchoolAdmission.Application.Features.CasteMasters.Queries;
using SchoolAdmission.Domain.Dtos;

public class GetAllCasteMastersHandler(ICasteMasterRepository repository) : IRequestHandler<GetAllCasteMastersQuery, List<CasteMasterQueryDto>>
{
    public async Task<List<CasteMasterQueryDto>> Handle(GetAllCasteMastersQuery request, CancellationToken cancellationToken)
    {
        // Assuming repository has GetAllWithCategoryAsync returning DTOs
        return await repository.GetAllAsync(cancellationToken);
    }
}