using HomeBudgetCalculator.Infrastructure.Commands.BudgetCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Handlers.Budgets
{
    public class CreateBudgetHandler : ICommandHandler<CreateBudget>
    {
        private readonly IBudgetService _budgetService;

        public CreateBudgetHandler(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }
        public async Task HandleAsync(CreateBudget command)
        {
            await _budgetService.CreateBudgetAsync(command.UserLogin);
        }
    }
}
