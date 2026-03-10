using MediatR;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Features.BranchMasters.Commands;

public class UpdateBranchMasterCommand : BranchMasterCommandDto, IRequest<bool>;