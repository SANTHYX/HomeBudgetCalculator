using HomeBudgetCalculator.Infrastructure.Commands.Interfaces;
using System;

namespace HomeBudgetCalculator.Infrastructure.Commands.BudgetCommands
{
    public class UpdateBudget : ICommand
    {
        public Guid Id { get; set; }

        public decimal BudgetAmount { get; set; }

        public decimal TotalIncome { get; set; }

        public decimal TotalExpense { get; set; }
    }
}
