using MediatR;
using SchoolAdmission.Domain.Entities;

namespace SchoolAdmission.Application.Features.StudentDetails.Commands;

public class CreateStudentSignUpCommand : StudentSignUpDto, IRequest<Guid>;
