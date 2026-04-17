using MediatR;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.CommiteMasters.Commands;

public class UpdateCommiteMasterCommand : CommiteMasterCommandDto, IRequest<ApiResponse<bool>>;
