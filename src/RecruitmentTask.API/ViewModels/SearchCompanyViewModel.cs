using System;
using System.Collections.Generic;

namespace RecruitmentTask.API.ViewModels
{
    public class SearchCompanyViewModel
    {
        public string Keyword { get; set; } = "";
        public DateTime EmployeeDateOfBirthFrom { get; set; }
        public DateTime EmployeeDateOfBirthTo { get; set; }
        public List<string> EmployeesJobTitle { get; set; } = new List<string>();
    }
}
