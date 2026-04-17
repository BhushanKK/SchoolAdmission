using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.SubjectMasters.Queries;

public class GetSubjectMasterByIdHandler(ISubjectMasterRepository repository)
    : IRequestHandler<GetSubjectMasterByIdQuery, ApiResponse<SubjectMasterQueryDto?>>
{
    public async Task<ApiResponse<SubjectMasterQueryDto?>> Handle(
        GetSubjectMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.SubjectId, cancellationToken);

        if (entity is null)
            return ApiResponse<SubjectMasterQueryDto?>.FailureResponse(
                MessageHelper.NotFound(EntityEnum.SubjectMaster, request.SubjectId),
                HttpStatusCode.NotFound.GetHashCode()
            );

        return ApiResponse<SubjectMasterQueryDto?>.SuccessResponse(
            new SubjectMasterQueryDto
            {
                SubjectId = entity.SubjectId,
                BranchId = entity.BranchId,
                GroupId = entity.GroupId,
                SubjectName = entity.SubjectName
            },
            MessageHelper.RetrievedSuccessfully(EntityEnum.SubjectMaster),
            HttpStatusCode.OK.GetHashCode()
        );
    }
}