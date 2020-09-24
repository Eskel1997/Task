using MediatR;
using RecruitmentTask.INFRATRUCTURE.DTOs;
using System.Collections.Generic;

namespace RecruitmentTask.INFRATRUCTURE.Commands
{
    public class EditCompanyCommand : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public List<EmployeeDTO> Employees { get; set; }

        public EditCompanyCommand(long id, string name, int establishmentYear, List<EmployeeDTO> employees)
        {
            Id = id;
            Name = name;
            EstablishmentYear = establishmentYear;
            Employees = employees;
        }
    }
}
