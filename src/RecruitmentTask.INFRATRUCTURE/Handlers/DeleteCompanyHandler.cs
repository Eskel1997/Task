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
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, Unit>
    {
        private readonly ICompanyRepository companyRepository;
        public DeleteCompanyHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await this.companyRepository.GetByIdAsync(request.Id);
            if(company == null)
            {
                throw new RecruitmentTaskException(ErrorCode.CompanyNotExist);
            }
            company.Employees.Clear();
            this.companyRepository.Delete(company);
            await this.companyRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
