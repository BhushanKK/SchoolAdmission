using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.SchoolMasters.Commands;

public class UpdateSchoolMasterCommand : SchoolMasterCommandDto, IRequest<ApiResponse<bool>>;
