using HomeBudgetCalculator.Infrastructure.Commands.BudgetCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Handlers.Budgets
{
    public class InitializeBudgetHandler : ICommandHandler<InitializeBudget>
    {
        private readonly IBudgetService _budgetService;

        public InitializeBudgetHandler(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }
        public async Task HandleAsync(InitializeBudget command)
        {
            await _budgetService.InitializeBudgetAsync(command.UserLogin);
        }
    }
}
