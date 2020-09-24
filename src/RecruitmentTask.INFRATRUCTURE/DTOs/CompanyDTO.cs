using RecruitmentTask.Core.Entities;
using System.Collections.Generic;

namespace RecruitmentTask.INFRATRUCTURE.DTOs
{
    public class CompanyDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
    }
}
