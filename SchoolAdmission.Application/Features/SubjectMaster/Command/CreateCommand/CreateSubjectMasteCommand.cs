using MediatR;
using SchoolAdmission.Domain.Dto;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.SubjectMasters.Commands;

public class CreateSubjectMasterCommand :SubjectMasterCommandDto, IRequest<ApiResponse<int>>;
