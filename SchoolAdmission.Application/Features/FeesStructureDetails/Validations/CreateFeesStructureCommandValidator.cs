using FluentValidation;
using SchoolAdmission.Application.Features.FeesStructureDetails.Commands;

namespace SchoolAdmission.Application.Validators;

public class CreateFeesStructureCommandValidator : AbstractValidator<CreateFeesStructureCommand>
{
    public CreateFeesStructureCommandValidator()
    {
        RuleFor(x => x.FeeHeadDescription)
            .NotEmpty().WithMessage("Fee head description is required")
            .MaximumLength(100);

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero");

        RuleFor(x => x.BranchId)
            .NotEmpty().WithMessage("Branch Id is required");
    }
}

public class UpdateFeesStructureCommandValidator : AbstractValidator<UpdateFeesStructureCommand>
{
    public UpdateFeesStructureCommandValidator()
    {
        RuleFor(x => x.FeeId)
            .GreaterThan(0).WithMessage("Valid Fee Id is required");

        RuleFor(x => x.FeeHeadDescription)
            .NotEmpty().WithMessage("Fee head description is required")
            .MaximumLength(100);

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero");

        RuleFor(x => x.BranchId)
            .NotEmpty().WithMessage("Branch Id is required");
    }
}