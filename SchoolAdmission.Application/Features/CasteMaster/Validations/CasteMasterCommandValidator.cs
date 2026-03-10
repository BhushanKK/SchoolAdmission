using FluentValidation;
using SchoolAdmission.Application.Features.CasteMasters.Commands;

namespace SchoolAdmission.Application.Validators;

public class CreateCasteMasterCommandValidator : AbstractValidator<CreateCasteMasterCommand>
{
    public CreateCasteMasterCommandValidator()
    {
        RuleFor(x => x.CasteId)
            .NotEmpty().WithMessage("Caste id is required");
            
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