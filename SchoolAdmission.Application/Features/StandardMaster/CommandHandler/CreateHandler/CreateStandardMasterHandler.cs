using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.StandardMasters.Commands;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Infrastructure.Interfaces;
using System.Net;
using SchoolAdmission.Domain.Utils;

public class CreateStandardMasterHandler(
        IMapper mapper,
        ILogger<CreateStandardMasterHandler> logger,
        ApplicationDbContext context,
        ICurrentUserRepository currentUser
    ) : IRequestHandler<CreateStandardMasterCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(CreateStandardMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            
            var standardMaster = mapper.Map<StandardMaster>(request);

            
            standardMaster.EntryBy = await currentUser.Email;
            standardMaster.EntryDate = DateTime.UtcNow;

            
            await context.StandardMasters.AddAsync(standardMaster, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            
            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<int>.SuccessResponse(
                standardMaster.StandardId,
                MessageHelper.CreatedSuccessfully(EntityEnum.StandardMaster),
                HttpStatusCode.Created.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex, "Error while creating StandardMaster");

            return ApiResponse<int>.FailureResponse(
                MessageHelper.InternalServerError(EntityEnum.StandardMaster),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}
