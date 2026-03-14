using MediatR;
//using SchoolAdmission.Application.Interfaces;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.SchoolMasters.Queries;

public class GetSchoolMasterByIdHandler(ISchoolMasterRepository repository)
        : IRequestHandler<GetSchoolMasterByIdQuery, SchoolMasterQueryDto?>
{
    public async Task<SchoolMasterQueryDto?> Handle(
        GetSchoolMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id, cancellationToken);
    }
}