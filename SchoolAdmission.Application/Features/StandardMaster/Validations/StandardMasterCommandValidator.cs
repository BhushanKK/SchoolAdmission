using FluentValidation;
using SchoolAdmission.Application.Features.StandardMasters.Commands;
using SchoolAdmission.Domain.Dtos;

namespace SchoolAdmission.Application.Validators;

public class CreateStandardMasterCommandValidator : AbstractValidator<CreateStandardMasterCommand>
{
    public CreateStandardMasterCommandValidator(IStandardMasterRepository repository)
    {
        RuleFor(x => x.StandardName)
            .NotEmpty().WithMessage("Standard name is required")
            .MaximumLength(100)
            .MustAsync(async (StandardName, ct) =>
            !await repository.IsExistsAsync(StandardName, ct))
            .WithMessage("STandard  already exists.");
    }
}

public class UpdateStandardMasterCommandValidator : AbstractValidator<UpdateStandardMasterCommand>
{
    public UpdateStandardMasterCommandValidator()
    {
        RuleFor(x => x.StandardId)
            .GreaterThan(0).WithMessage("Valid Standard Id is required");

        RuleFor(x => x.StandardName)
            .NotEmpty().WithMessage("Standard name is required")
            .MaximumLength(50).WithMessage("Standard name must not exceed 50 characters");
    }
}
