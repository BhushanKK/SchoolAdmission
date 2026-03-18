using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.CommiteMasters.Commands;
public class UpdateCommiteMasterCommand : CommiteMasterCommandDto, IRequest<bool>;