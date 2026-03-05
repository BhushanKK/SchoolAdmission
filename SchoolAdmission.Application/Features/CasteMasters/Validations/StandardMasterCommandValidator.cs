using FluentValidation;
using SchoolAdmission.Application.Dtos;

namespace SchoolAdmission.Application.Validators;

public class CreateStandardMasterCommandValidator : AbstractValidator<StandardMasterDto>
{
    public CreateStandardMasterCommandValidator()
    {
        RuleFor(x => x.StandardName)
            .NotEmpty().WithMessage("Standard name is required")
            .MaximumLength(50).WithMessage("Standard name must not exceed 50 characters");
    }
}