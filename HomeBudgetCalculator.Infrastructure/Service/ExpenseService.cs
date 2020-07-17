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

        public Task AddExpenseAsync(Guid budgetId, string title, decimal value, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task DeleteExpenseAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExpenseAsync(Guid id, string title, decimal value, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
