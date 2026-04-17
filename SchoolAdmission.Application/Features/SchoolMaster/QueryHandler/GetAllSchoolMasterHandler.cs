using System.Net;
using MediatR;
using SchoolAdmission.Domain;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.SchoolMasters.Queries;

public class GetAllSchoolMasterHandler(ISchoolMasterRepository repository)
    : IRequestHandler<GetAllSchoolMasterQuery, ApiResponse<List<SchoolMaster>>>
{
    public async Task<ApiResponse<List<SchoolMaster>>> Handle(GetAllSchoolMasterQuery request, 
    CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(request.CommiteeId ?? 0, cancellationToken);

        return ApiResponse<List<SchoolMaster>>.SuccessResponse(data.Select(x => new SchoolMaster
        {
            SchoolId = x.SchoolId,
            SchoolName = x.SchoolName,
            CommiteeId = x.CommiteeId,
            CommitteeName = x.CommitteeName,
            Status = x.Status,
            LogoPath = x.LogoPath
        }).ToList(), MessageHelper.RetrievedSuccessfully(EntityEnum.SchoolMaster), HttpStatusCode.OK.GetHashCode());
    }
}
