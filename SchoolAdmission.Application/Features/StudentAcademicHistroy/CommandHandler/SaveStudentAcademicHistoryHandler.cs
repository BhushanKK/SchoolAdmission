using MediatR;
using SchoolAdmission.Domain.Utils;
public class SaveStudentAcademicHistoryHandler(IStudentAcademicHistoryRepository repo) 
    : IRequestHandler<SaveStudentAcademicHistoryCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(SaveStudentAcademicHistoryCommand request, CancellationToken cancellationToken)
    {
        int result = await repo.SaveStudentAcademicHistoryAsync(request, cancellationToken);
        if(result>0)
        {
            return new ApiResponse<int>
            {
                Success = true,
                Data = result,
                Message = MessageHelper.CreatedSuccessfully(EntityEnum.StudentAcademicHistory)
            };
        }
        else
        {
            return new ApiResponse<int>
            {
                Success = false,
                Message = MessageHelper.InternalServerError(EntityEnum.StudentAcademicHistory)
            };
        }
    }
}
