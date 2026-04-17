using MediatR;
using SchoolAdmission.Domain.ResponseModels;

namespace SchoolAdmission.Application.Features.CommiteMasters.Commands;
public record CreateCommiteMasterCommand(string CommiteeName, bool Status, string Slogan) : 
IRequest<ApiResponse<int>>;
