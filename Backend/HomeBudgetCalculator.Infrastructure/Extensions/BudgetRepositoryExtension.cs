using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using System;
using System.Linq;

namespace HomeBudgetCalculator.Infrastructure.Extensions
{
    public static class BudgetRepositoryExtension
    {
        public static bool IsBudgetExist(this IBudgetRepository budgetRepository, Guid id)
        {
            var budgetExist = budgetRepository.GetAll().Where(x => x.Id == id).Any();

            if (budgetExist)
            {
                return true;
            }

            return false;
        }
    }
}
