using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.DivisionMasters.Commands;

public class CreateDivisionMasterCommand : DivisionMasterCommandDto, IRequest<ApiResponse<int>>;

