using MediatR;
using SchoolAdmission.Domain.Dto;

namespace SchoolAdmission.Application.Features.SubjectMasters.Commands;

public class CreateSubjectMasterCommand :SubjectMasterCommandDto, IRequest<ApiResponse<int>>;
