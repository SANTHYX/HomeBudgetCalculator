using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using System;
using System.Linq;

namespace HomeBudgetCalculator.Infrastructure.Extensions
{
    public static class IncomeExtension
    {
        public static bool IsIncomeExist(this IIncomeRepository incomeRepository,Guid id)
        {
            var income = incomeRepository.GetAll().Where(x => x.Id == id);
            var incomeExist = income.Any();

            if (incomeExist)
            {
                return true;
            }

            return false;
        }

        public static decimal CalculateTotalIncome(this IIncomeRepository incomeRepository,
            Guid budgetId)
        {
            var totalIncome = incomeRepository.GetAll()
                .Where(x => x.BudgetId == budgetId).Sum(z => z.Value);

            return totalIncome;
        }
    }
}
