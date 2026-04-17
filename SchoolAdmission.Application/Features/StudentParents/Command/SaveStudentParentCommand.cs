using MediatR;
using SchoolAdmission.Domain.Dto;

namespace SchoolAdmission.Application.Features.StudentParents.Commands;
public class SaveStudentParentCommand : StudentParentsDto, IRequest<ApiResponse<int>>;
