using System;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Service.Interfaces
{
    public interface IExpenseService : IService
    {
        Task AddExpenseAsync(Guid budgetId, string title, decimal value, DateTime date);

        Task DeleteExpenseAsync(Guid id);

        Task UpdateExpenseAsync(Guid id ,string title, decimal value,
            DateTime date);
    }
}
