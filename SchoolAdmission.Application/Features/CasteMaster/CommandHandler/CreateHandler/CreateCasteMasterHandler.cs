using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.CasteMasters.Commands;
using SchoolAdmission.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net;

public class CreateCasteMasterHandler(IMapper mapper, ICurrentUserRepository currentUser,
    ILogger<CreateCasteMasterHandler> logger, ApplicationDbContext context) : IRequestHandler<CreateCasteMasterCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(CreateCasteMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var casteMaster = mapper.Map<CasteMaster>(request);
            casteMaster.EntryBy = await currentUser.Email;
            casteMaster.EntryDate = DateTime.UtcNow;
            await context.CasteMasters.AddAsync(casteMaster, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return ApiResponse<int>.SuccessResponse(casteMaster.CasteId, "CasteMaster created successfully", HttpStatusCode.Created.GetHashCode());
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex.Message, "Failed to create CasteMaster");
            return ApiResponse<int>.FailureResponse("Failed to create CasteMaster", HttpStatusCode.InternalServerError.GetHashCode());
        }
    }
}