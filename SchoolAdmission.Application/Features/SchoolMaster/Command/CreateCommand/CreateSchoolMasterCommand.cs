using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.SchoolMasters.Commands;

public class CreateSchoolMasterCommand : SchoolMasterCommandDto, IRequest<ApiResponse<int>>;
