using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using System;
using System.Linq;

namespace HomeBudgetCalculator.Infrastructure.Extensions
{
    public static class IncomeRepositoryExtension
    {
        public static bool IsIncomeExist(this IIncomeRepository incomeRepository,Guid id)
        {
            var incomeExist = incomeRepository.GetAll().Where(x => x.Id == id).Any();

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
                .Where(x => x.BudgetId == budgetId).Sum(y => y.Value);

            return totalIncome;
        }
    }
}
