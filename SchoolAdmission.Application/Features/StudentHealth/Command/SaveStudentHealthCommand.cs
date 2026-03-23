using MediatR;
using SchoolAdmission.Domain.Dtos;

public class SaveStudentHealthCommand : StudentHealthDto, IRequest<int>
{
}
