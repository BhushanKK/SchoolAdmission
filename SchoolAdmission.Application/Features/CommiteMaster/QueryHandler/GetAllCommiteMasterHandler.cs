using System.Net;
using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.CommiteMasters.Queries;

public class GetAllCommiteMastersHandler(ICommiteMasterRepository repository,
    ILogger<GetAllCommiteMastersHandler> logger)
    : IRequestHandler<GetAllCommiteMastersQuery, ApiResponse<List<CommiteMasterQueryDto>>>
{
    public async Task<ApiResponse<List<CommiteMasterQueryDto>>> Handle(GetAllCommiteMastersQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var data = await repository.GetAllAsync(cancellationToken);

            return ApiResponse<List<CommiteMasterQueryDto>>.SuccessResponse
            (
                data,
                MessageHelper.RetrievedSuccessfully(EntityEnum.CommiteMaster),
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while fetching CommiteMaster list");
            return ApiResponse<List<CommiteMasterQueryDto>>.FailureResponse
            (
                "Unable to fetch CommiteMaster records at the moment.",
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}
