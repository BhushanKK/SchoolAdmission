using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Domain.ResponseModels;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Data;
using SchoolAdmission.Infrastructure.Interfaces;
using System.Net;

namespace SchoolAdmission.Application.Features.StudentDocuments.Commands;

public class DeleteStudentDocumentHandler(
    IStudentDocumentRepository repository,
    ILogger<DeleteStudentDocumentHandler> logger,
    ApplicationDbContext context,IWebHostEnvironment env)
    : IRequestHandler<DeleteStudentDocumentCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle( DeleteStudentDocumentCommand request,
     CancellationToken cancellationToken)
    {
        await using var transaction =
            await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var entity = await repository.GetByIdAsync(request.DocumentId,cancellationToken);

            if (entity == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = MessageHelper.NotFound( EntityEnum.StudentDocument,request.DocumentId),
                    StatusCode = HttpStatusCode.NotFound.GetHashCode()
                };
            }
            // DELETE FILE FROM UPLOADS FOLDER
            if (!string.IsNullOrEmpty(entity.DocumentPath))
            {
                var filePath = Path.Combine(env.WebRootPath,entity.DocumentPath);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

            }

            await repository.DeleteAsync(entity,cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return ApiResponse<bool>.SuccessResponse(
                true,
                MessageHelper.DeletedSuccessfully(EntityEnum.StudentDocument),
                HttpStatusCode.OK.GetHashCode()
            );
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(
                "An error occurred while deleting StudentDocument with Id {Id}",
                request.DocumentId
            );

            return ApiResponse<bool>.FailureResponse(
                MessageHelper.InternalServerError(EntityEnum.StudentDocument),
                HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}