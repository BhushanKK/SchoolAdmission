using FluentValidation;
using SchoolAdmission.Application.Features.ReligionMasters.Commands;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Application.Validators;

public class CreateReligionMasterCommandValidator : AbstractValidator<CreateReligionMasterCommand>
{
    public CreateReligionMasterCommandValidator(IReligionMasterRepository repository)
    {
        RuleFor(x => x.Religion)
            .NotEmpty();
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

