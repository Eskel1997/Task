using RecruitmentTask.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentTask.Core.Entities
{
    public class Company

    {
        private Company() {}
        public long Id { get; private set; }
        public string Name { get; private set; }
        public int EstablishmentYear { get; private set; }
        public List<Employee> Employees { get; private set; } = new List<Employee>();

        public Company(string name, int establishmentYear)
        {
            SetName(name);
            SetEstablishmentYear(establishmentYear);
        }

        public void Update(string name, int establishmentYear, List<Employee> employees)
        {
            SetName(name);
            SetEstablishmentYear(establishmentYear);
            SetEmployees(employees);
        }

        public void SetName(string name)
            => Name = name;
        public void SetEstablishmentYear(int establishmentYear)
            => EstablishmentYear = establishmentYear;
        public void SetEmployees(List<Employee> employees)
            => Employees = employees;

    }
}
