using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.CommiteMasters.Commands;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

public class CreateCommiteMasterHandler(IMapper mapper, ICurrentUserRepository currentUser,ILogger<CreateCommiteMasterHandler> logger,
    ApplicationDbContext context) : IRequestHandler<CreateCommiteMasterCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(CreateCommiteMasterCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
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