using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.SchoolMasters.Queries;

public class GetSchoolMasterByIdHandler(ISchoolMasterRepository repository)
    : IRequestHandler<GetSchoolMasterByIdQuery, SchoolMaster?>
{
    public async Task<SchoolMaster?> Handle(
        GetSchoolMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id, cancellationToken);
    }
}