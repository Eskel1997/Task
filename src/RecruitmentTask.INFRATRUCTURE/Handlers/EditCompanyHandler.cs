using MediatR;
using RecruitmentTask.Core.Entities;
using RecruitmentTask.Core.Exceptions;
using RecruitmentTask.Core.Repositories.Abstract;
using RecruitmentTask.INFRATRUCTURE.Commands;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecruitmentTask.INFRATRUCTURE.Handlers
{
    public class EditCompanyHandler : IRequestHandler<EditCompanyCommand, Unit>
    {
        private readonly ICompanyRepository companyRepository;
        public EditCompanyHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(EditCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await this.companyRepository.GetByIdAsync(request.Id);
            if (company == null)
            {
                throw new RecruitmentTaskException(ErrorCode.CompanyNotExist);
            }

            company.Employees.Clear();
            var employes = new List<Employee>();
            request.Employees.ForEach(x => employes.Add(new Employee(x.FirstName, x.LastName, x.DateOfBirth, x.JobTitle, company)));
            company.Update(request.Name, request.EstablishmentYear, employes);
            this.companyRepository.Update(company);
            await this.companyRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
