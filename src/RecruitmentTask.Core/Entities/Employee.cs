using RecruitmentTask.Core.Enums;
using System;

namespace RecruitmentTask.Core.Entities
{
    public class Employee
    {
        private Employee() { }
        public Employee(string firstName, string lastName, DateTime dateOfBirth, string position, Company company)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetDateOfBirth(dateOfBirth);
            SetPosition(position);
            SetCompany(company);
        }
        public long Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public PositionTypeEnum JobTitle { get; private set; }
        public long CompanyId { get; private set; }
        public virtual Company Company { get; private set; }

        public void SetFirstName(string firstName)
            => FirstName = firstName;

        public void SetLastName(string lastName)
            => LastName = lastName;

        public void SetDateOfBirth(DateTime dateOfBirth)
            => DateOfBirth = dateOfBirth;

        public void SetPosition(string jobTitle)
            => JobTitle = (PositionTypeEnum) Enum.Parse(typeof(PositionTypeEnum),jobTitle, true);

        public void SetCompany(Company company)
            => Company = company;

    }
}
