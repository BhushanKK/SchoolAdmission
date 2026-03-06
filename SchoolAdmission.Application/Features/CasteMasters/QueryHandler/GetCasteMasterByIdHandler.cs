using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.CasteMasters.Queries;

public class GetCasteMasterByIdHandler(ICasteMasterRepository repository)
    : IRequestHandler<GetCasteMasterByIdQuery, CasteMasterQueryDto?>
{
    public async Task<CasteMasterQueryDto?> Handle(GetCasteMasterByIdQuery request,CancellationToken cancellationToken)
    {
        return await repository.GetByIdWithCategoryAsync(request.Id,cancellationToken);
    }
}