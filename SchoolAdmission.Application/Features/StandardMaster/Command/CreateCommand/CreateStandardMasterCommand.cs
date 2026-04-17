using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.StandardMasters.Commands;

public class CreateStandardMasterCommand : StandardMasterCommandDto, IRequest<ApiResponse<int>>;
