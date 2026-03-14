using MediatR;
//using SchoolAdmission.Application.Interfaces;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.SchoolMasters.Queries;

public class GetAllSchoolMasterHandler(ISchoolMasterRepository repository)
        : IRequestHandler<GetAllSchoolMastersQuery, List<SchoolMasterQueryDto>>
{
    public async Task<List<SchoolMasterQueryDto>> Handle(
        GetAllSchoolMastersQuery request,
        CancellationToken cancellationToken)
    {
        return await repository.GetAllAsync(cancellationToken);
    }
}