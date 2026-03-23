using System.Net;
using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.SchoolMasters.Queries;

public class GetSchoolMasterByIdHandler(ISchoolMasterRepository repository)
    : IRequestHandler<GetSchoolMasterByIdQuery, ApiResponse<SchoolMasterQueryDto?>>
{
    public async Task<ApiResponse<SchoolMasterQueryDto?>> Handle(
        GetSchoolMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);

        if (entity == null)
            return ApiResponse<SchoolMasterQueryDto?>.FailureResponse("SchoolMaster not found", 404);

        return ApiResponse<SchoolMasterQueryDto?>.SuccessResponse(new SchoolMasterQueryDto
        {
            SchoolId= entity.SchoolId,
            SchoolName = entity.SchoolName
        }, MessageHelper.RetrievedSuccessfully(EntityEnum.SchoolMaster), HttpStatusCode.OK.GetHashCode());
    }
}
          