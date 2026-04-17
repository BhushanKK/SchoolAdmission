using MediatR;
using SchoolAdmission.Domain.Dto;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StudentParents.Commands;
public class SaveStudentParentCommand : StudentParentsDto, IRequest<ApiResponse<int>>;
