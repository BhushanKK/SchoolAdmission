using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.SchoolMasters.Commands;

public class UpdateSchoolMasterCommand : SchoolMasterCommandDto, IRequest<ApiResponse<bool>>;
