using MediatR;

namespace SchoolAdmission.Application.Features.BranchMasters.Commands;

public record DeleteBranchMasterCommand(int Id) : IRequest<bool>;