using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.BranchMasters.Commands;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Infrastructure.Interfaces;

public class CreateBranchMasterHandler(IMapper mapper, ILogger<CreateBranchMasterHandler> logger,
    ApplicationDbContext context, ICurrentUserRepository currentUser)
    : IRequestHandler<CreateBranchMasterCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(CreateBranchMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var branchMaster = mapper.Map<BranchMaster>(request);

            branchMaster.EntryBy = await currentUser.Email;
            branchMaster.EntryDate = DateTime.UtcNow;

            await context.BranchMasters.AddAsync(branchMaster, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return ApiResponse<int>.SuccessResponse(branchMaster.BranchId, "Branch created successfully", 201);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex, "Error while creating BranchMaster");
            return ApiResponse<int>.FailureResponse("Unable to create BranchMaster at the moment. Please try again later.", 500);
        }
    }
}
