using System;
using System.Collections.Generic;

namespace HomeBudgetCalculator.Infrastructure.DTO
{
    public class BudgetDTO
    {
        public Guid Id { get; set; }

        public decimal BudgetAmount { get; set; }

        public decimal TotalIncome { get; set; }

        public decimal TotalExpense { get; set; }

        public IEnumerable<IncomeDTO> Incomes { get; set; }

        public IEnumerable<ExpenseDTO> Expenses { get; set; }
    }
}

