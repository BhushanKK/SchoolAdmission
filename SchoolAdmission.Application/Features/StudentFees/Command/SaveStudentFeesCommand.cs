using MediatR;
using SchoolAdmission.Domain.Dtos;

public class SaveStudentFeesCommand : StudentFeesDto, IRequest<int>
{
}
