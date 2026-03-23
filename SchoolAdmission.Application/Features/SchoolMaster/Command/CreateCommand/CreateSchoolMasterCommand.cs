using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.SchoolMasters.Commands;

public class CreateSchoolMasterCommand : SchoolMasterCommandDto, IRequest<ApiResponse<int>>;