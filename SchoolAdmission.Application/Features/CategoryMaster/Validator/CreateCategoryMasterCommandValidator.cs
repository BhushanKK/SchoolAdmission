using FluentValidation;
using SchoolAdmission.Application.Features.CategoryMasters.Commands;

namespace SchoolAdmission.Application.Validators;

public class CreateCategoryMasterCommandValidator : AbstractValidator<CreateCategoryMasterCommand>
{
    public CreateCategoryMasterCommandValidator()
    {
        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category name is required")
            .MaximumLength(100);
    }
}

public class UpdateCategoryMasterCommandValidator : AbstractValidator<UpdateCategoryMasterCommand>
{
    public UpdateCategoryMasterCommandValidator()
    {
        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Valid Category Id is required");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category name is required")
            .MaximumLength(100);
    }
}