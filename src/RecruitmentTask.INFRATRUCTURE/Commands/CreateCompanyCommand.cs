using MediatR;
using RecruitmentTask.INFRATRUCTURE.DTOs;
using System.Collections.Generic;

namespace RecruitmentTask.INFRATRUCTURE.Commands
{
    public class CreateCompanyCommand : IRequest<long>
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
    }
}
