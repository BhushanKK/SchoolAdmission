using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.StudentAcademicHistory.Commands;
public class SaveStudentAcademicHistoryCommand : StudentAcademicHistoryDto, IRequest<ApiResponse<int>>;
