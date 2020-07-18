using HomeBudgetCalculator.Infrastructure.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBudgetCalculator.Infrastructure.Commands.BudgetCommands
{
    public class InitialBudget : ICommand
    {
        public string UserLogin { get; set; }
    }
}
