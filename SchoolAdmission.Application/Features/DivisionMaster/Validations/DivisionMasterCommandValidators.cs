using FluentValidation;
using SchoolAdmission.Application.Features.DivisionMasters.Commands;

namespace SchoolAdmission.Application.Validators
{
    // Validator for CreateDivisionMasterCommand
    public class CreateDivisionMasterCommandValidator : AbstractValidator<CreateDivisionMasterCommand>
    {
        public CreateDivisionMasterCommandValidator()
        {
            RuleFor(x => x.DivisionName)
                .NotEmpty().WithMessage("Division name is required")
                .MaximumLength(100);
        }
    }

    // Validator for UpdateDivisionMasterCommand
    public class UpdateDivisionMasterCommandValidator : AbstractValidator<UpdateDivisionMasterCommand>
    {
        public UpdateDivisionMasterCommandValidator()
        {
            RuleFor(x => x.DivisionId)
                .GreaterThan(0).WithMessage("Valid Division Id is required");

            RuleFor(x => x.DivisionName)
                .NotEmpty().WithMessage("Division name is required")
                .MaximumLength(100);
        }
    }
}