using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.EntityFramework.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Repositories.Interfaces
{
    public interface IIncomeRepository : IRepository, ISqlRepository
    {
        Task AddAsync(Income income);

        Task DeleteAsync(Income income);

        Task UpdateAsync(Income income);

        Task<Income> GetAsync(Guid id);

        IQueryable<Income> GetAll();
    }
}
