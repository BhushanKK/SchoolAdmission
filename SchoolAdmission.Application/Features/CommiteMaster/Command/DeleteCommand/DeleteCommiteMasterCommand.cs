using MediatR;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.CommiteMasters.Commands;

public record DeleteCommiteMasterCommand(int Id) : IRequest<ApiResponse<bool>>;
