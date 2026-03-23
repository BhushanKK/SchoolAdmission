using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.ReligionMasters.Commands;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Infrastructure.Interfaces;
using System.Net;
using SchoolAdmission.Domain.Utils;
public class CreateReligionMasterHandler(
        IMapper mapper,
        ILogger<CreateReligionMasterHandler> logger,
        ApplicationDbContext context,
        ICurrentUserRepository currentUser
    ) : IRequestHandler<CreateReligionMasterCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(CreateReligionMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            
            var religionMaster = mapper.Map<ReligionMaster>(request);

            
            religionMaster.EntryBy = await currentUser.Email;
            religionMaster.EntryDate = DateTime.UtcNow;

            
            await context.ReligionMasters.AddAsync(religionMaster, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            
            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<int>.SuccessResponse(
                religionMaster.ReligionId,
                MessageHelper.CreatedSuccessfully(EntityEnum.ReligionMaster),
                HttpStatusCode.Created.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex, "Error while creating ReligionMaster");
            return ApiResponse<int>.FailureResponse(
                MessageHelper.InternalServerError(EntityEnum.ReligionMaster),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}
