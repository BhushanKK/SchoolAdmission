using MediatR;
using SchoolAdmission.Application.Dtos;

namespace SchoolAdmission.Application.Features.CasteMasters.Commands;

public class UpdateCasteMasterCommand : CasteMasterDto, IRequest<bool>;