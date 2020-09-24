using FluentValidation;
using FluentValidation.Results;
using RecruitmentTask.API.ViewModels;

namespace RecruitmentTask.API.Validation
{
    public class SearchCompanyValidator : AbstractValidator<SearchCompanyViewModel>
    {
        public override ValidationResult Validate(ValidationContext<SearchCompanyViewModel> context)
        {
            RuleFor(x => x.EmployeeDateOfBirthTo)
                .GreaterThan(x => x.EmployeeDateOfBirthFrom);

            return base.Validate(context);
        }
    }
}
