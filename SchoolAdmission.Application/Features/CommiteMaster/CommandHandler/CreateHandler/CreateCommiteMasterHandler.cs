using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.CommiteMasters.Commands;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using static SchoolAdmission.Domain.Utils.CommanEnums;
using System.Net;

namespace SchoolAdmission.Application.Features.CommiteMasters.Commands;
public class CreateCommiteMasterHandler(IMapper mapper, ICurrentUserRepository currentUser,ILogger<CreateCommiteMasterHandler> logger,ICommiteMasterRepository commiteMasterRepository,
    ApplicationDbContext context) : IRequestHandler<CreateCommiteMasterCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(CreateCommiteMasterCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {   var isExist = await commiteMasterRepository.IsExistsAsync(request.CommiteeName!, OperationType.Create, null, cancellationToken);
            
            if (isExist)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Message = MessageHelper.AlreadyExists(request.CommiteeName!),
                    StatusCode = HttpStatusCode.Conflict.GetHashCode()
                };
            }
            var commiteMaster = mapper.Map<CommiteMaster>(request);
            commiteMaster.EntryBy = await currentUser.Email;
            commiteMaster.EntryDate = DateTime.UtcNow;
            await context.CommiteMasters.AddAsync(commiteMaster, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return ApiResponse<int>.SuccessResponse(commiteMaster.CommiteeId, MessageHelper.CreatedSuccessfully(EntityEnum.CommiteeMaster), System.Net.HttpStatusCode.Created.GetHashCode());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while creating CommiteMaster");
            await transaction.RollbackAsync(cancellationToken);
            return ApiResponse<int>.FailureResponse(MessageHelper.InternalServerError(EntityEnum.CommiteeMaster), System.Net.HttpStatusCode.InternalServerError.GetHashCode());
        }
    }
}
