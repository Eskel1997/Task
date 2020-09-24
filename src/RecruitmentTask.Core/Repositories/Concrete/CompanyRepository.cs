using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Core.Entities;
using RecruitmentTask.Core.Exceptions;
using RecruitmentTask.Core.Repositories.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTask.Core.Repositories.Concrete
{
    internal class CompanyRepository : ICompanyRepository
    {
        private readonly RecruitmentTaskContext context;
        public CompanyRepository(RecruitmentTaskContext context)
        {
            this.context = context;
        }

        public async Task<Company> GetByIdAsync(long id)
        {
            return await this.context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddAsync(Company employer)
        {
            await this.context.Companies.AddAsync(employer);
        }

        public void Delete(Company employer)
        {
            this.context.Remove(employer);
        }

        public IQueryable<Company> GetQueryable()
        {
            return this.context.Companies.AsQueryable();
        }

        public async Task SaveChangesAsync()
        {
            if (await this.context.SaveChangesAsync() < 0)
                throw new RecruitmentTaskException(ErrorCode.DatabaseSavingException);
        }

        public void Update(Company employer)
        {
            this.context.Companies.Update(employer);
        }
    }
}
