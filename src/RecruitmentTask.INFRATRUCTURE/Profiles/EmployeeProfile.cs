using AutoMapper;
using RecruitmentTask.Core.Entities;
using RecruitmentTask.INFRATRUCTURE.DTOs;

namespace RecruitmentTask.INFRATRUCTURE.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
        }
    }
}
