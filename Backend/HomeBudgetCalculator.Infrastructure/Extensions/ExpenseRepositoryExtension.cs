using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using System;
using System.Linq;

namespace HomeBudgetCalculator.Infrastructure.Extensions
{
    public static class ExpenseRepositoryExtension
    {
        public static bool IsExpenseExist(this IExpenseRepository expenseRepository, Guid id)
        {
            var expenseExist = expenseRepository.GetAll().Where(x => x.Id == id).Any();

            if (expenseExist)
            {
                return true;
            }

            return false;
        }

        public static decimal CalculateTotalExpense(this IExpenseRepository expenseRepository,
            Guid budgetId)
        {
            var totalExpense = expenseRepository.GetAll()
                .Where(x => x.BudgetId == budgetId).Sum(z => z.Value);

            return totalExpense;
        }
    }
}
