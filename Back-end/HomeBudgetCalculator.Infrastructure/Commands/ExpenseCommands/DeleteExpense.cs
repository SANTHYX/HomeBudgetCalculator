using HomeBudgetCalculator.Infrastructure.Commands.Interfaces;
using System;

namespace HomeBudgetCalculator.Infrastructure.Commands.ExpenseCommands
{
    public class DeleteExpense : ICommand
    {
        public Guid Id { get; set; }
    }
}
