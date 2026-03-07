using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.DivisionMasters.Queries;

public class GetDivisionMasterByIdHandler(IDivisionMasterRepository repository)
    : IRequestHandler<GetDivisionMasterByIdQuery, DivisionMasterQueryDto?>
{
    public async Task<DivisionMasterQueryDto?> Handle(GetDivisionMasterByIdQuery request,CancellationToken cancellationToken)
    {
        return await repository.GetByIdWithCategoryAsync(request.Id,cancellationToken);
    }
}