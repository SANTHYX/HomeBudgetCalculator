using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Repositories.Interfaces
{
    public interface IBudgetRepository : IRepository, ISqlRepository
    {
        Task AddAsync(Budget budget);

        Task UpdateAsync(Budget budget);

        Task DeleteAsync(Budget budget);

        Budget GetAsync(Guid id);

        Task<Budget> GetByUserIdAsync(Guid userId);

        IQueryable<Budget> GetAllAsync();
    }
}
