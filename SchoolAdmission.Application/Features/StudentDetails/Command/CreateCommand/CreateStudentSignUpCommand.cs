using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.StudentDetails.Commands;

public class CreateStudentSignUpCommand : StudentSignUpDto, IRequest<Guid>;
