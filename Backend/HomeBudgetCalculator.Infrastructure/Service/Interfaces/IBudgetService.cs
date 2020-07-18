using System;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Service.Interfaces
{
    public interface IBudgetService : IService
    {
        Task InitializeBudgetAsync(string login);

        Task UpdateBudgetAsync(Guid id);
    }
}
