using System.Net;
using MediatR;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.SubjectMasters.Queries;

public class GetAllSubjectMasterHandler(ISubjectMasterRepository repository)
    : IRequestHandler<GetAllSubjectMasterQuery, ApiResponse<List<SubjectMaster>>>
{
    public async Task<ApiResponse<List<SubjectMaster>>> Handle(
        GetAllSubjectMasterQuery request,
        CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return ApiResponse<List<SubjectMaster>>.SuccessResponse(
            data.Select(x => new SubjectMaster
            {
                SubjectId = x.SubjectId,
                BranchId = x.BranchId,
                GroupId = x.GroupId,
                SubjectName = x.SubjectName
            }).ToList(),
            MessageHelper.RetrievedSuccessfully(EntityEnum.SubjectMaster),
            HttpStatusCode.OK.GetHashCode()
        );
    }
}