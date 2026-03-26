using MediatR;
using SchoolAdmission.Domain.Utils;
using SchoolAdmission.Infrastructure.Interfaces;

public class SaveStudentFeesHandler(IStudentFeesRepository repo)
    : IRequestHandler<SaveStudentFeesCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(SaveStudentFeesCommand request, CancellationToken cancellationToken)
    {
        int result = await repo.SaveStudentFeesAsync(request, cancellationToken);
        if (result > 0)
        {
            return new ApiResponse<int>
            {
                Success = true,
                Data = result,
                Message = MessageHelper.CreatedSuccessfully(EntityEnum.StudentFees)
            };
        }

        return new ApiResponse<int>
        {
            Success = false,
            Message = MessageHelper.InternalServerError(EntityEnum.StudentFees)
        };
    }
}
