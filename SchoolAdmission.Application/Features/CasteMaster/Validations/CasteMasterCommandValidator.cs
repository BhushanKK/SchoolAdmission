using FluentValidation;
using SchoolAdmission.Application.Features.CasteMasters.Commands;
using SchoolAdmission.Infrastructure.Interfaces;

namespace SchoolAdmission.Application.Validators;

public class CreateCasteMasterCommandValidator : AbstractValidator<CreateCasteMasterCommand>
{
    public CreateCasteMasterCommandValidator(ICasteMasterRepository repository)
    {
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Category id is required");

        RuleFor(x => x.Caste)
            .NotEmpty().WithMessage("Caste name is required")
            .MaximumLength(100)
            .MustAsync(async (caste, ct) =>!await repository.IsExistsAsync(caste,"Create", null, ct))
            .WithMessage("Caste already exists.");
    }
}

public class UpdateCasteMasterCommandValidator : AbstractValidator<UpdateCasteMasterCommand>
{
    public UpdateCasteMasterCommandValidator()
    {
        RuleFor(x => x.CasteId)
            .GreaterThan(0).WithMessage("Valid Caste Id is required");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Category Id is required");
    }
}
