using HomeBudgetCalculator.Infrastructure.Commands.Interfaces;

namespace HomeBudgetCalculator.Infrastructure.Commands.BudgetCommands
{
    public class InitializeBudget : ICommand
    {
        public string UserLogin { get; set; }
    }
}
