using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net;
using SchoolAdmission.Domain.Utils;
using static SchoolAdmission.Domain.Utils.CommanEnums;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;
public class CreateCasteMasterHandler(IMapper mapper, ICurrentUserRepository currentUser,ICasteMasterRepository casteMasterRepository,
    ILogger<CreateCasteMasterHandler> logger, ApplicationDbContext context) : IRequestHandler<CreateCasteMasterCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(CreateCasteMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var isExist = await casteMasterRepository.IsExistsAsync(request.Caste!, OperationType.Create, null, cancellationToken);
            
            if (isExist)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Message = MessageHelper.AlreadyExists(request.Caste!),
                    StatusCode = HttpStatusCode.Conflict.GetHashCode()
                };
            }

            var casteMaster = mapper.Map<CasteMaster>(request);
            casteMaster.EntryBy = await currentUser.Email;
            casteMaster.EntryDate = DateTime.UtcNow;
            await context.CasteMasters.AddAsync(casteMaster, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return ApiResponse<int>.SuccessResponse(casteMaster.CasteId, MessageHelper.CreatedSuccessfully(EntityEnum.CasteMaster), HttpStatusCode.Created.GetHashCode());
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex.Message, "Failed to create CasteMaster");
            return ApiResponse<int>.FailureResponse(MessageHelper.InternalServerError(EntityEnum.CasteMaster), HttpStatusCode.InternalServerError.GetHashCode());
        }
    }
}
