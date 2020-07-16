using HomeBudgetCalculator.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Service.Interfaces
{
    public interface IIncomeService : IService
    {
        Task AddIncomeAsync();

        Task UpdateIncomeAsync();

        Task DeleteIncomeAsync();
    }
}
