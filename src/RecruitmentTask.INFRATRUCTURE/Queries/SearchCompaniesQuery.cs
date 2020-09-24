using MediatR;
using RecruitmentTask.INFRATRUCTURE.DTOs;
using System;
using System.Collections.Generic;

namespace RecruitmentTask.INFRATRUCTURE.Queries
{
    public class SearchCompaniesQuery : IRequest<FilteredCompanyResponseDTO>
    {
        public string Keyword { get; set; }
        public DateTime EmployeeDateOfBirthFrom { get; set; }
        public DateTime EmployeeDateOfBirthTo { get; set; }
        public List<string> EmployeesJobTitle { get; set; }
    }
}
