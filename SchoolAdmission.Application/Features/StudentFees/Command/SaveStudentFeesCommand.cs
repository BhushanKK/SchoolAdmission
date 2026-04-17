using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.StudentFees.Commands;
public class SaveStudentFeesCommand : StudentFeesDto, IRequest<ApiResponse<int>>;

