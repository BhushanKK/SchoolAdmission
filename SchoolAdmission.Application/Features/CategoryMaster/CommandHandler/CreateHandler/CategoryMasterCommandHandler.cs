using MediatR;
using AutoMapper;
using SchoolAdmission.Domain;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Application.Features.CategoryMasters.Commands;
using SchoolAdmission.Infrastructure.Interfaces;
using SchoolAdmission.Domain.Utils;
using System.Net;
using Microsoft.Extensions.Logging;
using static SchoolAdmission.Domain.Utils.CommanEnums;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.CategoryMasters.Commands;
public class CreateCategoryMasterHandler(IMapper mapper,ILogger<CreateCategoryMasterHandler> logger, ICurrentUserRepository currentUser,ICategoryMasterRepository categoryMasterRepository,
    ApplicationDbContext context) : IRequestHandler<CreateCategoryMasterCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(CreateCategoryMasterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {   
            var isExist = await categoryMasterRepository.IsExistsAsync(request.Category!, OperationType.Create, null, cancellationToken);
            
            if (isExist)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Message = MessageHelper.AlreadyExists(request.Category!),
                    StatusCode = HttpStatusCode.Conflict.GetHashCode()
                };
            }
            var categoryMaster = mapper.Map<CategoryMaster>(request);
            categoryMaster.EntryBy = await currentUser.Email;
            categoryMaster.EntryDate = DateTime.UtcNow;
            await context.CategoryMasters.AddAsync(categoryMaster, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return ApiResponse<int>.SuccessResponse(categoryMaster.categoryId, MessageHelper.CreatedSuccessfully(EntityEnum.CategoryMaster), HttpStatusCode.Created.GetHashCode());
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex.Message, "Failed to create CategoryMaster");
            return ApiResponse<int>.FailureResponse(MessageHelper.InternalServerError(EntityEnum.CategoryMaster), HttpStatusCode.InternalServerError.GetHashCode());
        }
    }
}
