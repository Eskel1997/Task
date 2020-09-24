using RecruitmentTask.Core.Enums;
using System;

namespace RecruitmentTask.INFRATRUCTURE.DTOs
{
    public class EmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JobTitle { get; set; }
    }
}
