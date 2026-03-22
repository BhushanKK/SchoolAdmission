using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.DivisionMasters.Commands;

public class CreateDivisionMasterCommand : DivisionMasterCommandDto, IRequest<ApiResponse<int>>;
