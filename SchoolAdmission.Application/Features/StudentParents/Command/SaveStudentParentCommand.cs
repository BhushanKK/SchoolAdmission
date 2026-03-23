using MediatR;
using SchoolAdmission.Domain.Dto;

public class SaveStudentParentCommand : StudentParentsDto, IRequest<ApiResponse<int>>;
