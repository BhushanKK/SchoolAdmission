using System.Net;
using MediatR;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;
using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Application.Features.SubjectMasters.Queries;

public class GetSubjectMasterByIdHandler(ISubjectMasterRepository repository)
        : IRequestHandler<GetSubjectMasterByIdQuery, ApiResponse<SubjectMaster>>
{
    public async Task<ApiResponse<SubjectMaster>> Handle(
        GetSubjectMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var data = await repository.GetByIdAsync(request.SubjectId,cancellationToken);

        if (data == null)
        {
            return ApiResponse<SubjectMaster>.FailureResponse(
                MessageHelper.NotFound(EntityEnum.SubjectMaster,request.SubjectId),
                HttpStatusCode.NotFound.GetHashCode()
            );
        }

        return ApiResponse<SubjectMaster>.SuccessResponse(
            data,
            MessageHelper.RetrievedSuccessfully(EntityEnum.SubjectMaster),
            HttpStatusCode.OK.GetHashCode()
        );
    }
}