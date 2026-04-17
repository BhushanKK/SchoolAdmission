using MediatR;
using SchoolAdmission.Domain.Dto;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.BranchMasters.Commands;

public class UpdateSubjectMasterCommand : SubjectMasterCommandDto, IRequest<ApiResponse<bool>>;
