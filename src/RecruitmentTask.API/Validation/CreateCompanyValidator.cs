using FluentValidation;
using FluentValidation.Results;
using RecruitmentTask.API.ViewModels;
using System;

namespace RecruitmentTask.API.Validation
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyViewModel>
    {
        public override ValidationResult Validate(ValidationContext<CreateCompanyViewModel> context)
        {
            RuleFor(c => c.Name)
                 .NotEmpty()
                 .NotNull()
                 .WithMessage("Company name is required");

            RuleFor(c => c.EstablishmentYear)
                .LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("Bad EstablishmentYear")
                .GreaterThan(0)
                .WithMessage("Bad EstablishmentYear");

            var employeeValidator = new EmployeeValidator();
            RuleForEach(c => c.Employees).SetValidator(employeeValidator);

            return base.Validate(context);
        }
    }
}
