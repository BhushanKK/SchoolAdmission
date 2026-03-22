using MediatR;
using SchoolAdmission.Domain.Dtos;

public class SaveStudentAcademicHistoryCommand : StudentAcademicHistoryDto, IRequest<int>
{
}