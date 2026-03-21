using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.StandardMasters.Queries;

public class GetStandardMasterByIdHandler(IStandardMasterRepository repository)
    : IRequestHandler<GetStandardMasterByIdQuery, StandardMasterQueryDto?>
{
    public async Task<StandardMasterQueryDto?> Handle(
        GetStandardMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);

        if (entity == null)
            return null;

        return new StandardMasterQueryDto
        {
            StandardId= entity.StandardId,
            StandardName = entity.StandardName
        };
    }
}
          