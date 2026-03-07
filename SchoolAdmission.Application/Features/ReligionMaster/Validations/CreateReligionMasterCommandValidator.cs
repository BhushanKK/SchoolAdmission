using FluentValidation;
using SchoolAdmission.Domain.Dtos;
using SchoolAdmission.Application.Features.Religions.Commands;

namespace SchoolAdmission.Application.Validators;

public class CreateReligionMasterCommandValidator : AbstractValidator<ReligionMasterCommandDto>
{
    public CreateReligionMasterCommandValidator()
    {
        RuleFor(x => x.Religion)
            .NotEmpty().WithMessage("Religion name is required")
            .MaximumLength(50).WithMessage("Religion name must not exceed 50 characters");
    }
}

public class UpdateReligionMasterCommandValidator : AbstractValidator<UpdateReligionMasterCommand>
{
    public UpdateReligionMasterCommandValidator()
    {
        RuleFor(x => x.ReligionId)
            .GreaterThan(0).WithMessage("Valid Religion Id is required");

        RuleFor(x => x.Religion)
            .NotEmpty().WithMessage("Religion name is required")
            .MaximumLength(50).WithMessage("Religion name must not exceed 50 characters");
    }
}
