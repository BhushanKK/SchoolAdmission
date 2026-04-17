using MediatR;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Domain.ResponseModels;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Features.StudentDocuments.Commands;
public class SaveStudentDocumentHandler(IStudentDocumentRepository repository)
    : IRequestHandler<SaveStudentDocumentCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(
        SaveStudentDocumentCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            if (request.File == null || request.File.Length == 0)
            {
                return ApiResponse<int>.FailureResponse
                (
                    "File is required",
                    System.Net.HttpStatusCode.BadRequest.GetHashCode()
                );
            }

            if (request.File.Length > 5 * 1024 * 1024)
            {
                return ApiResponse<int>.FailureResponse
                (
                    "File size must not exceed 5MB",
                    System.Net.HttpStatusCode.BadRequest.GetHashCode()
                );
            }

            var allowedExtensions = new[] { ".pdf", ".jpg", ".jpeg", ".png" };
            var extension = Path.GetExtension(request.File.FileName).ToLower();

            if (!allowedExtensions.Contains(extension))
            {
                return ApiResponse<int>.FailureResponse(
                    "Only PDF, JPG, JPEG, PNG files are allowed",
                    System.Net.HttpStatusCode.BadRequest.GetHashCode()
                );
            }

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{Guid.NewGuid()}{extension}";
            var fullPath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await request.File.CopyToAsync(stream, cancellationToken);
            }

            request.DocumentPath = $"Uploads/{fileName}";
            request.UploadedDate = DateTime.UtcNow;

            int result = await repository.SaveStudentDocumentAsync(request, cancellationToken);

            if (result > 0)
            {
                return ApiResponse<int>.SuccessResponse
                (
                    result,
                    MessageHelper.CreatedSuccessfully(EntityEnum.StudentDocument),
                    System.Net.HttpStatusCode.Created.GetHashCode()
                );
            }

            return ApiResponse<int>.FailureResponse
            (
                MessageHelper.InternalServerError(EntityEnum.StudentDocument),
                System.Net.HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<int>.FailureResponse
            (
                ex.Message,
                System.Net.HttpStatusCode.InternalServerError.GetHashCode()
            );
        }
    }
}