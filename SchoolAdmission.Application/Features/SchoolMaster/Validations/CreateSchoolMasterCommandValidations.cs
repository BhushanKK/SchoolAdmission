using FluentValidation;
using SchoolAdmission.Application.Features.SchoolMasters.Commands;

namespace SchoolAdmission.Application.Validators
{
    // Validator for CreateSchoolMasterCommand
    public class CreateSchoolMasterCommandValidator : AbstractValidator<CreateSchoolMasterCommand>
    {
        public CreateSchoolMasterCommandValidator()
        {
            RuleFor(x => x.SchoolName)
                .NotEmpty().WithMessage("School name is required")
                .MaximumLength(100);
            
            
        }
    }

    // Validator for UpdateSchoolMasterCommand
    public class UpdateSchoolMasterCommandValidator : AbstractValidator<UpdateSchoolMasterCommand>
    {
        public UpdateSchoolMasterCommandValidator()
        {
            RuleFor(x => x.SchoolId)
                .GreaterThan(0).WithMessage("Valid School Id is required");

            RuleFor(x => x.SchoolName)
                .NotEmpty().WithMessage("School name is required")
                .MaximumLength(100);

            RuleFor(x => x.CommiteeId)
                .NotEmpty().WithMessage("Commitee ID is required");

            
        }
    }
}