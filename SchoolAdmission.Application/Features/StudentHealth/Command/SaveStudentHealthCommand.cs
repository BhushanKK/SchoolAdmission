using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.StudentHealth.Commands;
public class SaveStudentHealthCommand : StudentHealthDto, IRequest<ApiResponse<int>>;
