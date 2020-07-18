using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.Extensions;
using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Service
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IBudgetRepository _budgetRepository;

        public ExpenseService(IExpenseRepository expenseRepository, IBudgetRepository budgetRepository)
        {
            _expenseRepository = expenseRepository;
            _budgetRepository = budgetRepository;
        }

        public async Task AddExpenseAsync(Guid budgetId, string title, decimal value, DateTime date)
        {
            if (!_budgetRepository.IsBudgetExist(budgetId))
            {
                throw new Exception("Cannot relate Income with Budget that doesn't exist");
            }

            await _expenseRepository.AddAsync(new Expense(title, value, date,budgetId));
        }

        public async Task DeleteExpenseAsync(Guid id)
        {
            if (!_expenseRepository.IsExpenseExist(id))
            {
                throw new Exception("Income object not exist");
            }

            var expense = await _expenseRepository.GetAsync(id);
            await _expenseRepository.DeleteAsync(expense);
        }

        public async Task UpdateExpenseAsync(Guid id, string title, decimal value, DateTime date)
        {
            if (!_expenseRepository.IsExpenseExist(id))
            {
                throw new Exception("Income object not exist");
            }

            var expense = await _expenseRepository.GetAsync(id);
            expense.SetTitle(title);
            expense.SetValue(value);
            expense.SetDate(date);
            await _expenseRepository.UpdateAsync(expense);
        }
    }
}
