using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Service.Interfaces
{
    public interface IExpenseService : IService
    {
        Task DeleteExpenseAsync();

        Task AddExpenseAsync();

        Task UpdateExpenseAsync();
    }
}
