using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.SchoolMasters.Commands;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Infrastructure.Interfaces;
using System.Net;
using SchoolAdmission.Domain.Utils;

public class CreateSchoolMasterHandler(
        IMapper mapper, 
        ILogger<CreateSchoolMasterHandler> logger,
        ApplicationDbContext context, 
        ICurrentUserRepository currentUser
    ) : IRequestHandler<CreateSchoolMasterCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(CreateSchoolMasterCommand request, 
    CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            // Map the command to the SchoolMaster entity
            var schoolMaster = mapper.Map<SchoolMaster>(request);

            // Set audit fields
            schoolMaster.EntryBy = await currentUser.Email;
            schoolMaster.EntryDate = DateTime.UtcNow;

            // Add and save to DB
            await context.SchoolMasters.AddAsync(schoolMaster, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            // Commit transaction
            await transaction.CommitAsync(cancellationToken);

            return ApiResponse<int>.SuccessResponse(
                schoolMaster.SchoolId,
                MessageHelper.CreatedSuccessfully(EntityEnum.SchoolMaster),
                HttpStatusCode.Created.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex, "Error while creating SchoolMaster");

            return ApiResponse<int>.FailureResponse(
                MessageHelper.InternalServerError(EntityEnum.SchoolMaster),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}