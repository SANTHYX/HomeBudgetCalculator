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
    }
}
