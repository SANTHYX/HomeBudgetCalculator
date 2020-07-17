using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.EntityFramework;
using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly DataContext _context;

        public ExpenseRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expense expense)
        {
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Expense> GetAllAsync()
            => _context.Expenses.AsQueryable();

        public async Task<Expense> GetAsync(Guid id)
            => await _context.Expenses.FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(Expense expense)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }
    }
}
