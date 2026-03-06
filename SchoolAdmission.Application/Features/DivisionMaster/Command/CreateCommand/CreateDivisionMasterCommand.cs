using MediatR;
using SchoolAdmission.Application.Dtos;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.DivisionMasters.Commands;

public class CreateDivisionMasterCommand : DivisionMasterCommandDto, IRequest<int>;