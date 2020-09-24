using RecruitmentTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentTask.Core.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(long id);
        IQueryable<Employee> GetQueryable();
        Task AddAsync(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        Task SaveChangesAsync();
    }
}
