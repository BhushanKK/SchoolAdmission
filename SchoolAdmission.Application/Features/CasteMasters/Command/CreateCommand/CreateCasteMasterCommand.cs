using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public class CreateCasteMasterCommand : CasteMasterDto, IRequest<int>;