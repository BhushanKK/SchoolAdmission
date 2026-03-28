using FluentValidation;
using SchoolAdmission.Application.Features.DivisionMasters.Commands;
using SchoolAdmission.Infrastructure.Interfaces;
using static SchoolAdmission.Domain.Utils.CommanEnums;

namespace SchoolAdmission.Application.Validators;


public class CreateDivisionMasterCommandValidator : AbstractValidator<CreateDivisionMasterCommand>
{
    public CreateDivisionMasterCommandValidator(IDivisionMasterRepository repository)
    {
        RuleFor(x => x.DivisionName)
            .NotEmpty().WithMessage("Division name is required")
            .MaximumLength(100)
            .MustAsync(async (DivisionName, ct) =>!await repository.IsExistsAsync( DivisionName,OperationType.Create,null,ct))
            .WithMessage("Division already exists.");  
            
    }
}


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


