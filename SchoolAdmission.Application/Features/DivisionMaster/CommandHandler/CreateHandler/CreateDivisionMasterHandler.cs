using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.DivisionMasters.Commands;
using SchoolAdmission.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net;
using SchoolAdmission.Domain.Utils;

public class CreateDivisionMasterHandler(
    IMapper mapper, 
    ICurrentUserRepository currentUser,
    ILogger<CreateDivisionMasterHandler> logger, 
    ApplicationDbContext context
) : IRequestHandler<CreateDivisionMasterCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(CreateDivisionMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            // Map command to entity
            var division = mapper.Map<DivisionMaster>(request);
            
            // Set metadata
            division.EntryBy = await currentUser.Email;
            division.EntryDate = DateTime.UtcNow;

            // Add to DB
            await context.DivisionMasters.AddAsync(division, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            // Commit transaction
            await transaction.CommitAsync(cancellationToken);

            // Return success
            return ApiResponse<int>.SuccessResponse(
                division.DivisionId,
                MessageHelper.CreatedSuccessfully(EntityEnum.DivisionMaster),
                HttpStatusCode.Created.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            // Rollback in case of error
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex, "Failed to create DivisionMaster");

            // Return failure response
            return ApiResponse<int>.FailureResponse(
                MessageHelper.InternalServerError(EntityEnum.DivisionMaster),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}