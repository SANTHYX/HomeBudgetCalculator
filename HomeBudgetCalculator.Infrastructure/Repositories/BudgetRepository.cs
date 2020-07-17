using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.EntityFramework;
using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly DataContext _context;

        public BudgetRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Budget budget)
        {
            await _context.Budgets.AddAsync(budget);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Budget> GetAll()
            => _context.Budgets.AsQueryable();

        public async Task<Budget> GetAsync(Guid id)
            => await _context.Budgets.Include(x => x.Incomes).Include(y => y.Expenses)
            .FirstOrDefaultAsync(z => z.Id == id);

        public async Task DeleteAsync(Budget budget)
        {
            _context.Budgets.Remove(budget);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Budget budget)
        {
            _context.Budgets.Update(budget);
            await _context.SaveChangesAsync();
        }
    }
}
