using AutoMapper;
using RecruitmentTask.API.ViewModels;
using RecruitmentTask.INFRATRUCTURE.Commands;
using RecruitmentTask.INFRATRUCTURE.Queries;

namespace RecruitmentTask.API.Profiles
{
    public class CompanyProfiles : Profile
    {
        public CompanyProfiles()
        {
            CreateMap<CreateCompanyViewModel, CreateCompanyCommand>();
            CreateMap<SearchCompanyViewModel, SearchCompaniesQuery>();
        }
    }
}
