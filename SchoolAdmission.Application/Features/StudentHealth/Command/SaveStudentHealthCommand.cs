using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentHealth.Commands;
public class SaveStudentHealthCommand : StudentHealthDto, IRequest<ApiResponse<int>>;
