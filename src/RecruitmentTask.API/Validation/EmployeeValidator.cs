using FluentValidation;
using FluentValidation.Results;
using RecruitmentTask.Core.Enums;
using RecruitmentTask.INFRATRUCTURE.DTOs;
using System;

namespace RecruitmentTask.API.Validation
{
    public class EmployeeValidator : AbstractValidator<EmployeeDTO>
    {
        public override ValidationResult Validate(ValidationContext<EmployeeDTO> context)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Employee FirstName cannot be empty")
                .NotNull()
                .WithMessage("Enter Employee FirstName")
                .MaximumLength(20)
                .WithMessage("Employee FirstName to long, max lenght is 20");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Employee LastName cannot be empty")
                .NotNull()
                .WithMessage("Enter Employee LastName")
                .MaximumLength(20)
                .WithMessage("Employee LastName to long, max lenght is 20");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty();

            RuleFor(x => x.JobTitle)
                .Must(BeValidJob)
                .WithMessage("Please enter one of jobs name: Administrator, Developer, Architect, Manager");

            return base.Validate(context);
        }

        private bool BeValidJob(string value)
        {
            PositionTypeEnum job;
            return (Enum.TryParse(value, true, out job) && job != PositionTypeEnum.None) ? true : false;
        }
    }
}
