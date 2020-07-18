using HomeBudgetCalculator.Infrastructure.Commands.BudgetCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Handlers.Budgets
{
    public class UpdateBudgetHandler : ICommandHandler<UpdateBudget>
    {
        private readonly IBudgetService _budgetService;

        public UpdateBudgetHandler(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }
        public async Task HandleAsync(UpdateBudget command)
        {
            await _budgetService.UpdateBudgetAsync(command.Id);
        }
    }
}
