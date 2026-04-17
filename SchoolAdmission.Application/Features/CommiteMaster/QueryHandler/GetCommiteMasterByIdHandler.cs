using System.Net;
using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.CommiteMasters.Queries;

public class GetCommiteMasterByIdHandler(
    ICommiteMasterRepository repository,
    ILogger<GetCommiteMasterByIdHandler> logger)
    : IRequestHandler<GetCommiteMasterByIdQuery, ApiResponse<CommiteMasterQueryDto>>
{
    public async Task<ApiResponse<CommiteMasterQueryDto>> Handle(
        GetCommiteMasterByIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

            if (entity is null)
                return ApiResponse<CommiteMasterQueryDto>.FailureResponse(
                    MessageHelper.NotFound(EntityEnum.CommiteMaster, request.Id),
                    HttpStatusCode.NotFound.GetHashCode());

            var dto = new CommiteMasterQueryDto
            {
                CommiteeId = entity.CommiteeId,
                CommiteeName = entity.CommiteeName
            };

            return ApiResponse<CommiteMasterQueryDto>.SuccessResponse
            (
                dto,
                MessageHelper.RetrievedSuccessfully(EntityEnum.CommiteMaster),
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            logger.LogError(ex,"Error while fetching CommiteMaster Id : {Id}",request.Id);
            return ApiResponse<CommiteMasterQueryDto>.FailureResponse
            (
                MessageHelper.InternalServerError(EntityEnum.CommiteMaster),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}
