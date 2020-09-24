using RecruitmentTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentTask.Core.Repositories.Abstract
{
    public interface ICompanyRepository
    {
        Task<Company> GetByIdAsync(long id);
        IQueryable<Company> GetQueryable();
        Task AddAsync(Company employer);
        void Update(Company employer);
        void Delete(Company employer);
        Task SaveChangesAsync();
    }
}
