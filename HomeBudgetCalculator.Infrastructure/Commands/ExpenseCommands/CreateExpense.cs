using HomeBudgetCalculator.Infrastructure.Commands.Interfaces;
using System;

namespace HomeBudgetCalculator.Infrastructure.Commands.ExpenseCommands
{
    public class CreateExpense : ICommand
    {
        public Guid BudgetId { get; set; }

        public string Title { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }
    }
}
