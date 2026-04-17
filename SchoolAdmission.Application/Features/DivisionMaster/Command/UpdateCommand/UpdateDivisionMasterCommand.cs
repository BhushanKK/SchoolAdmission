using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.DivisionMasters.Commands;

public class UpdateDivisionMasterCommand : DivisionMasterCommandDto, IRequest<ApiResponse<bool>>;
