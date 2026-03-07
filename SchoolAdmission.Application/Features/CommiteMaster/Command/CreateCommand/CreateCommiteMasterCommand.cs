using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.CommiteMasters.Commands;
public record CreateCommiteMasterCommand(string CommiteeName, bool Status, string Slogan) : 
IRequest<int>;