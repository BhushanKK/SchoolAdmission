using System.Net;
using MediatR;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.SubjectMasters.Queries;

public class GetAllSubjectMasterHandler(ISubjectMasterRepository repository)
    : IRequestHandler<GetAllSubjectMasterQuery, ApiResponse<List<SubjectMasterDto>>>
{
    public async Task<ApiResponse<List<SubjectMasterDto>>> Handle(
        GetAllSubjectMasterQuery request,
        CancellationToken cancellationToken)
    {
        var data = await repository.GetAllAsync(cancellationToken);

        return ApiResponse<List<SubjectMasterDto>>.SuccessResponse(
            data,
            MessageHelper.RetrievedSuccessfully(EntityEnum.SubjectMaster),
            HttpStatusCode.OK.GetHashCode()
        );
    }
}