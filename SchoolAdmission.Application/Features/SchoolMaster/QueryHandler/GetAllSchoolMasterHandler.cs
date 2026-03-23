using System.Net;
using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.SchoolMasters.Queries;

public class GetAllSchoolMasterHandler(ISchoolMasterRepository repository)
    : IRequestHandler<GetAllSchoolMasterQuery, ApiResponse<List<SchoolMaster>>>
{
    public async Task<ApiResponse<List<SchoolMaster>>> Handle(GetAllSchoolMasterQuery request, 
    CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return ApiResponse<List<SchoolMaster>>.SuccessResponse(data.Select(x => new SchoolMaster
        {
            SchoolId = x.SchoolId,
            SchoolName = x.SchoolName
        }).ToList(), MessageHelper.RetrievedSuccessfully(EntityEnum.SchoolMaster), HttpStatusCode.OK.GetHashCode());
    }
}
