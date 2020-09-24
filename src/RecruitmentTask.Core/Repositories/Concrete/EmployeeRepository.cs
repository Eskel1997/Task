using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Core.Entities;
using RecruitmentTask.Core.Exceptions;
using RecruitmentTask.Core.Repositories.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTask.Core.Repositories.Concrete
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly RecruitmentTaskContext context;
        public EmployeeRepository(RecruitmentTaskContext context)
        {
            this.context = context;
        }
        public async Task<Employee> GetByIdAsync(long id)
        {
            return await this.context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddAsync(Employee employee)
        {
            await this.context.Employees.AddAsync(employee);
        }

        public void Delete(Employee employee)
        {
            this.context.Remove(employee);
        }

        public IQueryable<Employee> GetQueryable()
        {
            return this.context.Employees.AsQueryable();
        }

        public async Task SaveChangesAsync()
        {
            if (await this.context.SaveChangesAsync() < 0)
                throw new RecruitmentTaskException(ErrorCode.DatabaseSavingException);
        }

        public void Update(Employee employee)
        {
            this.context.Employees.Update(employee);
        }
    }
}
