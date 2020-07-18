using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeBudgetCalculator.Infrastructure.Extensions
{
    public static class ExpenseExtension
    {
        public static bool IsExpenseExist(this IExpenseRepository expenseRepository, Guid id)
        {
            var expense = expenseRepository.GetAll().Where(x => x.Id == id);
            var expenseExist = expense.Any();

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
