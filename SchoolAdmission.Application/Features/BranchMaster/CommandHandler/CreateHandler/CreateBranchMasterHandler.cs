using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.BranchMasters.Commands;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Infrastructure.Interfaces;
using System.Net;
using SchoolAdmission.Domain.Utils;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Application.Features.BranchMasters.Commands;

public class CreateBranchMasterHandler(IMapper mapper, ILogger<CreateBranchMasterHandler> logger,
    ApplicationDbContext context, ICurrentUserRepository currentUser,IBranchMasterRepository branchMasterRepository)
    : IRequestHandler<CreateBranchMasterCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(CreateBranchMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {   
            var isExist = await branchMasterRepository.IsExistsAsync(request.BranchName!, OperationType.Create, null, cancellationToken);
            
            if (isExist)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Message = MessageHelper.AlreadyExists(request.BranchName!),
                    StatusCode = HttpStatusCode.Conflict.GetHashCode()
                };
            }
            var branchMaster = mapper.Map<BranchMaster>(request);

            branchMaster.EntryBy = await currentUser.Email;
            branchMaster.EntryDate = DateTime.UtcNow;

            await context.BranchMasters.AddAsync(branchMaster, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return ApiResponse<int>.SuccessResponse(branchMaster.BranchId, MessageHelper.CreatedSuccessfully(EntityEnum.BranchMaster), HttpStatusCode.Created.GetHashCode());
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex, "Error while creating BranchMaster");
            return ApiResponse<int>.FailureResponse(MessageHelper.InternalServerError(EntityEnum.BranchMaster), HttpStatusCode.InternalServerError.GetHashCode());
        }
    }
}

