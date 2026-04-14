using MediatR;
using SchoolAdmission.Domain.Dto;

namespace SchoolAdmission.Application.Features.BranchMasters.Commands;

public class UpdateSubjectMasterCommand : SubjectMasterCommandDto, IRequest<ApiResponse<bool>>;
