using MediatR;
using SchoolAdmission.Application.Dtos;
namespace SchoolAdmission.Application.Features.StandardMasters.Queries;

public class GetStandardMasterByIdHandler(IStandardMasterRepository repository)
    : IRequestHandler<GetStandardMasterByIdQuery, StandardMasterDto?>
{
    public async Task<StandardMasterDto?> Handle(
        GetStandardMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);

        if (entity == null)
            return null;

        return new StandardMasterDto
        {
            StandardId = entity.StandardId,
            //StandardName = entity.StandardName
        };
    }
}