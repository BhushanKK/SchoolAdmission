using FluentValidation;
using SchoolAdmission.Application.Features.CategoryMasters.Commands;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Application.Validators;

public class CreateCategoryMasterCommandValidator : AbstractValidator<CreateCategoryMasterCommand>
{
    public CreateCategoryMasterCommandValidator(ICategoryMasterRepository repository)
    {
        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category name is required")
            .MaximumLength(100)
            .MustAsync(async (Category, ct) =>!await repository.IsExistsAsync( Category,OperationType.Create,null,ct))
            .WithMessage("Category already exists.");   
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
