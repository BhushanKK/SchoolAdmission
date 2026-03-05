using FluentValidation;
using SchoolAdmission.Application.Features.CasteMasters.Commands;

namespace SchoolAdmission.Application.Validators;

public class CreateCasteMasterCommandValidator : AbstractValidator<CreateCasteMasterCommand>
{
    public CreateCasteMasterCommandValidator()
    {
        RuleFor(x => x.Caste)
            .NotEmpty().WithMessage("Caste name is required")
            .MaximumLength(100);
    }
}

public class UpdateCasteMasterCommandValidator : AbstractValidator<UpdateCasteMasterCommand>
{
    public UpdateCasteMasterCommandValidator()
    {
        RuleFor(x => x.CasteId)
            .GreaterThan(0).WithMessage("Valid Caste Id is required");

        RuleFor(x => x.Caste)
            .NotEmpty().WithMessage("Caste name is required")
            .MaximumLength(100);
    }
}