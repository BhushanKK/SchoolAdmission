using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.StandardMasters.Commands;

public class UpdateStandardMasterCommand : StandardMasterCommandDto,IRequest<bool>;