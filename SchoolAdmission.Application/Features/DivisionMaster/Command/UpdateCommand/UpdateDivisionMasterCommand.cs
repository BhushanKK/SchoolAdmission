using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.DivisionMasters.Commands;

public class UpdateDivisionMasterCommand : DivisionMasterCommandDto, IRequest<bool>;