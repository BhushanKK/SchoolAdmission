using FluentValidation;
using SchoolAdmission.Application.Features.SchoolMasters.Commands;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Application.Validators;


public class CreateSchoolMasterCommandValidator : AbstractValidator<CreateSchoolMasterCommand>
{
    public CreateSchoolMasterCommandValidator(ISchoolMasterRepository repository)
    {
        RuleFor(x => x.SchoolName)
            .NotEmpty().WithMessage("School name is required")
            .MaximumLength(100)
            .MustAsync(async (SchoolName, ct) =>!await repository.IsExistsAsync( SchoolName,OperationType.Create,null,ct))
            .WithMessage("School already exists.");  
    }
}

public class UpdateSchoolMasterCommandValidator : AbstractValidator<UpdateSchoolMasterCommand>
{
    public UpdateSchoolMasterCommandValidator()
    {
        RuleFor(x => x.SchoolId)
            .GreaterThan(0).WithMessage("Valid School Id is required");

        RuleFor(x => x.SchoolName)
            .NotEmpty().WithMessage("School name is required")
            .MaximumLength(100);
    }
}
