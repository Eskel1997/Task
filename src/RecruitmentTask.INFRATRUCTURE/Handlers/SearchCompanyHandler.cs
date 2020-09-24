using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Core.Entities;
using RecruitmentTask.Core.Enums;
using RecruitmentTask.Core.Repositories.Abstract;
using RecruitmentTask.INFRATRUCTURE.DTOs;
using RecruitmentTask.INFRATRUCTURE.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecruitmentTask.INFRATRUCTURE.Handlers
{
    public class SearchCompanyHandler : IRequestHandler<SearchCompaniesQuery, FilteredCompanyResponseDTO>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;
        public SearchCompanyHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        public async Task<FilteredCompanyResponseDTO> Handle(SearchCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = this.companyRepository
                .GetQueryable()
                .Include(x => x.Employees)
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                companies = companies.Where(c => c.Name.Contains(request.Keyword) || 
                c.Employees.Any(e => e.FirstName.Contains(request.Keyword) ||
                e.LastName.Contains(request.Keyword)));
            }

            if (request.EmployeeDateOfBirthFrom != DateTime.MinValue)
            {
                companies = companies.Where(x => x.Employees.All(c => c.DateOfBirth >= request.EmployeeDateOfBirthFrom));
            }

            if (request.EmployeeDateOfBirthTo != DateTime.MinValue)
            {
                companies = companies.Where(x => x.Employees.All(c => c.DateOfBirth <= request.EmployeeDateOfBirthTo));
            }

            if (request.EmployeesJobTitle.Count > 0)
            {
                HashSet<PositionTypeEnum> Jobs = new HashSet<PositionTypeEnum>();
                foreach (var jobTitle in request.EmployeesJobTitle.Distinct())
                {
                    try
                    {
                        Jobs.Add((PositionTypeEnum)Enum.Parse(typeof(PositionTypeEnum), jobTitle));
                    }
                    catch
                    {
                        Jobs.Add(PositionTypeEnum.None);
                    }
                }
                companies = companies.Where(x => x.Employees.Any(c => Jobs.Contains(c.JobTitle)));
            }

            var companyList =  await companies
                .Select(src => new CompanyDTO()
                {
                    Id = src.Id,
                    Name = src.Name,
                    EstablishmentYear = src.EstablishmentYear,
                    Employees = this.mapper.Map<List<Employee>,List<EmployeeDTO>>(src.Employees)
                    
                })
                .ToListAsync();

            var responseDTO = new FilteredCompanyResponseDTO()
            {
                Results = companyList
            };

            return responseDTO; 
        }
    }
}
