using FluentValidation;
using SchoolAdmission.Application.Features.CommiteMasters.Commands;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Validators;

public class CreateCommiteMasterCommandValidator : AbstractValidator<CreateCommiteMasterCommand>
{
    public CreateCommiteMasterCommandValidator(ICommiteMasterRepository repository)
    {
        RuleFor(x => x.CommiteeName)
            .NotEmpty().WithMessage("Commitee name is required")
            .MaximumLength(100); 

        RuleFor(x => x.Status)
            .NotNull().WithMessage("Status is required");

        RuleFor(x => x.Slogan)
            .MaximumLength(255).WithMessage("Slogan can be maximum 255 characters");
    }
}

public class UpdateCommiteMasterCommandValidator : AbstractValidator<UpdateCommiteMasterCommand>
{
    public UpdateCommiteMasterCommandValidator()
    {
        RuleFor(x => x.CommiteeId)
            .GreaterThan(0).WithMessage("Valid Commitee Id is required");

        RuleFor(x => x.CommiteeName)
            .NotEmpty().WithMessage("Commitee name is required")
            .MaximumLength(100);

        RuleFor(x => x.Status)
            .NotNull().WithMessage("Status is required");

        RuleFor(x => x.Slogan)
            .MaximumLength(255).WithMessage("Slogan is required");
    }
}
