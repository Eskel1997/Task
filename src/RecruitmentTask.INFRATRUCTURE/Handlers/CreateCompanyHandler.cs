using AutoMapper;
using MediatR;
using RecruitmentTask.Core.Entities;
using RecruitmentTask.Core.Repositories.Abstract;
using RecruitmentTask.INFRATRUCTURE.Commands;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecruitmentTask.INFRATRUCTURE.Handlers
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, long>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;
        public CreateCompanyHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        public async Task<long> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company(request.Name, request.EstablishmentYear);
            var employes = new List<Employee>();
            request.Employees.ForEach(x => employes.Add(new Employee(x.FirstName, x.LastName, x.DateOfBirth, x.JobTitle, company)));
            company.Employees.AddRange(employes);
            await this.companyRepository.AddAsync(company);
            await this.companyRepository.SaveChangesAsync();
            return company.Id;
        }
    }
}
