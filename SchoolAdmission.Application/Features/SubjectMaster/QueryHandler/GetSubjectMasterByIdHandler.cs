using System.Net;
using MediatR;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.SubjectMasters.Queries;

public class GetSubjectsGroupedByBranchHandler(ISubjectMasterRepository repository)
    : IRequestHandler<GetSubjectsGroupedByBranchQuery, ApiResponse<GroupedSubjectsDto>>
{
    public async Task<ApiResponse<GroupedSubjectsDto>> Handle(
        GetSubjectsGroupedByBranchQuery request,
        CancellationToken cancellationToken)
    {
        var result = await repository.GetGroupedByBranchAsync(request.BranchId, cancellationToken);

        // Optional: treat empty groups as not found
        if (result == null || result.Groups.Count == 0)
        {
            return ApiResponse<GroupedSubjectsDto>.FailureResponse(
                MessageHelper.NotFound(EntityEnum.SubjectMaster, request.BranchId),
                HttpStatusCode.NotFound.GetHashCode()
            );
        }

        return ApiResponse<GroupedSubjectsDto>.SuccessResponse(
            result,
            MessageHelper.RetrievedSuccessfully(EntityEnum.SubjectMaster),
            HttpStatusCode.OK.GetHashCode()
        );
    }
}