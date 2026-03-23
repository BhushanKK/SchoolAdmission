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
            
            var division = mapper.Map<DivisionMaster>(request);
            
            
            division.EntryBy = await currentUser.Email;
            division.EntryDate = DateTime.UtcNow;

            
            await context.DivisionMasters.AddAsync(division, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            
            await transaction.CommitAsync(cancellationToken);

            
            return ApiResponse<int>.SuccessResponse(
                division.DivisionId,
                MessageHelper.CreatedSuccessfully(EntityEnum.DivisionMaster),
                HttpStatusCode.Created.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex, "Failed to create DivisionMaster");

            
            return ApiResponse<int>.FailureResponse(
                MessageHelper.InternalServerError(EntityEnum.DivisionMaster),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}
