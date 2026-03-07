using MediatR;

namespace SchoolAdmission.Application.Features.CommiteMasters.Commands;

public record DeleteCommiteMasterCommand(int Id) : IRequest<bool>;