using FluentValidation;
using SchoolAdmission.Application.Dtos;

namespace SchoolAdmission.Application.Validators;

public class CreateCasteMasterCommandValidator : AbstractValidator<CasteMasterDto>
{
    public CreateCasteMasterCommandValidator()
    {
        RuleFor(x => x.Caste)
            .NotEmpty().WithMessage("Caste name is required")
            .MaximumLength(50).WithMessage("Caste name must not exceed 50 characters");
    }
}