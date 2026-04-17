using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentAcademicHistory.Commands;
public class SaveStudentAcademicHistoryCommand : StudentAcademicHistoryDto, IRequest<ApiResponse<int>>;
