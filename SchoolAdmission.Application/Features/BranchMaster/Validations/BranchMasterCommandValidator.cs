using FluentValidation;
using SchoolAdmission.Application.Features.BranchMasters.Commands;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Validators;

public class CreateBranchMasterCommandValidator : AbstractValidator<CreateBranchMasterCommand>
{
    public CreateBranchMasterCommandValidator(IBranchMasterRepository repository)
    {
        RuleFor(x => x.BranchName)
            .NotEmpty().WithMessage("Branch name is required")
            .MaximumLength(100);  
    }
}

public class UpdateBranchMasterCommandValidator : AbstractValidator<UpdateBranchMasterCommand>
{
    public UpdateBranchMasterCommandValidator()
    {
        RuleFor(x => x.BranchId)
            .GreaterThan(0).WithMessage("Valid Branch Id is required");

        RuleFor(x => x.BranchName)
            .NotEmpty().WithMessage("Branch name is required")
            .MaximumLength(100);
    }
}
