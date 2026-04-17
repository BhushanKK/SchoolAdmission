using MediatR;
using SchoolAdmission.Domain.Entities;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentDetails.Commands;

public class CreateStudentSignUpCommand : StudentSignUpDto, IRequest<ApiResponse<Guid>>;

