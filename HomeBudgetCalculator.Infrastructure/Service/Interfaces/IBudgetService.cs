using System;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Service.Interfaces
{
    public interface IBudgetService : IService
    {
        Task CreateBudgetAsync(string login);

        Task UpdateBudgetAsync(Guid id, decimal budgetAmount, decimal totalIncome, decimal totalExpense);
    }
}
