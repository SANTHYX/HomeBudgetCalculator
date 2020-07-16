using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.EntityFramework;
using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public IQueryable<Budget> GetAllAsync()
            => _context.Budgets.AsQueryable();

        public Budget GetAsync(Guid id)
            => _context.Budgets.FirstOrDefault(x => x.Id == id);

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

        public async Task<Budget> GetByUserIdAsync(Guid userId)
            => await _context.Budgets.FirstOrDefaultAsync(x => x.UserId == userId);
    }
}
