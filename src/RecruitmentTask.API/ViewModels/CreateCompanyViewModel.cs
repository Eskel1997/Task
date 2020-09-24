using RecruitmentTask.INFRATRUCTURE.DTOs;
using System.Collections.Generic;

namespace RecruitmentTask.API.ViewModels
{
    public class CreateCompanyViewModel
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
    }
}
