using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.EntityFramework;
using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly DataContext _context;

        public IncomeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Income expense)
        {
            await _context.Incomes.AddAsync(expense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Income expense)
        {
            _context.Incomes.Remove(expense);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Income> GetAllAsync()
            => _context.Incomes;

        public async Task<Income> GetAsync(Guid id)
            => await _context.Incomes.FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(Income expense)
        {
            _context.Incomes.Update(expense);
            await _context.SaveChangesAsync();
        }
    }
}
