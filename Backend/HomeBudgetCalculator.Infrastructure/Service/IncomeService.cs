using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.Exceptions;
using HomeBudgetCalculator.Infrastructure.Extensions;
using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Service
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IBudgetRepository _budgetRepository;

        public IncomeService(IIncomeRepository incomeRepository, IBudgetRepository budgetRepository)
        {
            _incomeRepository = incomeRepository;
            _budgetRepository = budgetRepository;
        }

        public async Task AddIncomeAsync(Guid budgetId, string title, decimal value, DateTime date)
        {
            if (!_budgetRepository.IsBudgetExist(budgetId))
            {
                throw new ServiceExceptions(ServiceErrorCodes.BudgetNotExist, 
                    "Cannot relate Income with Budget that doesn't exist");
            }

            await _incomeRepository.AddAsync(new Income(title, value, date, budgetId));
        }

        public async Task DeleteIncomeAsync(Guid id)
        {
            if (!_incomeRepository.IsIncomeExist(id))
            {
                throw new ServiceExceptions(ServiceErrorCodes.IncomeNotExist, 
                    "Income object not exist");
            }

            var income = await _incomeRepository.GetAsync(id);
            await _incomeRepository.DeleteAsync(income);
        }

        public async Task UpdateIncomeAsync(Guid id ,string title, decimal value, DateTime date)
        {
            if (!_incomeRepository.IsIncomeExist(id))
            {
                throw new ServiceExceptions(ServiceErrorCodes.IncomeNotExist, 
                    "Income object not exist");
            }

            var income = await _incomeRepository.GetAsync(id);
            income.SetTitle(title);
            income.SetValue(value);
            income.SetDate(date);
            await _incomeRepository.UpdateAsync(income);
        }
    }
}
