using System;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Service.Interfaces
{
    public interface IIncomeService : IService
    {
        Task AddIncomeAsync(Guid budgetId, string title, decimal value, 
            DateTime date);

        Task UpdateIncomeAsync(Guid id ,string title, decimal value, 
            DateTime date);

        Task DeleteIncomeAsync(Guid id);
    }
}
