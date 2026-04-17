using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentFees.Commands;
public class SaveStudentFeesCommand : StudentFeesDto, IRequest<ApiResponse<int>>;

