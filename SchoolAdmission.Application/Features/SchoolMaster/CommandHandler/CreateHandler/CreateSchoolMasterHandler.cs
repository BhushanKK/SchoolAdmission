using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Infrastructure.Interfaces;
using System.Net;
using SchoolAdmission.Domain.Utils;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Application.Features.SchoolMasters.Commands;
public class CreateSchoolMasterHandler(
        IMapper mapper, 
        ILogger<CreateSchoolMasterHandler> logger,
        ApplicationDbContext context, ISchoolMasterRepository schoolMasterRepository,
        ICurrentUserRepository currentUser
    ) : IRequestHandler<CreateSchoolMasterCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(CreateSchoolMasterCommand request, 
    CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var isExist = await schoolMasterRepository.IsExistsAsync(request.SchoolName!, OperationType.Create, null, cancellationToken); 
            if (isExist)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Message = MessageHelper.AlreadyExists(request.SchoolName!),
                    StatusCode = HttpStatusCode.Conflict.GetHashCode()
                };
            }
            
            var schoolMaster = mapper.Map<SchoolMaster>(request); 
            schoolMaster.EntryBy = await currentUser.Email;
            schoolMaster.EntryDate = DateTime.UtcNow; 
            await context.SchoolMasters.AddAsync(schoolMaster, cancellationToken);
            await context.SaveChangesAsync(cancellationToken); 
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
