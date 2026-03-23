using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.Utils;
public class SaveStudentAcademicHistoryHandler(IStudentAcademicHistoryRepository repo) 
    : IRequestHandler<SaveStudentAcademicHistoryCommand, ApiResponse<int>>
{
    public async Task<ApiResponse<int>> Handle(SaveStudentAcademicHistoryCommand request, CancellationToken cancellationToken)
    {
        var dto = new StudentAcademicHistoryDto
        {
            AcademicHistoryId = request.AcademicHistoryId,
            StudentId = request.StudentId,
            PreviousSchool = request.PreviousSchool,
            SchoolDOE = request.SchoolDOE,
            Progress = request.Progress,
            Behaviour = request.Behaviour,
            PassingYear = request.PassingYear,
            SeatNo = request.SeatNo,
            TotalMarks = request.TotalMarks,
            Percentage = request.Percentage
        };

        int result = await repo.SaveStudentAcademicHistoryAsync(dto, cancellationToken);
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
