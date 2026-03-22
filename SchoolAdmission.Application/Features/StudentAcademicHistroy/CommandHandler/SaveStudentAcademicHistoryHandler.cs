using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Infrastructure.Interfaces;

public class SaveStudentAcademicHistoryHandler(IStudentAcademicHistoryRepository repo) 
    : IRequestHandler<SaveStudentAcademicHistoryCommand, int>
{
    public async Task<int> Handle(SaveStudentAcademicHistoryCommand request, CancellationToken cancellationToken)
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

        return await repo.SaveStudentAcademicHistoryAsync(dto, cancellationToken);
    }
}