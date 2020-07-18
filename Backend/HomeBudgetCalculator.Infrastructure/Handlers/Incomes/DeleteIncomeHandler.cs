using HomeBudgetCalculator.Infrastructure.Commands.IncomeCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Handlers.Incomes
{
    public class DeleteIncomeHandler : ICommandHandler<DeleteIncome>
    {
        private readonly IIncomeService _incomeService;

        public DeleteIncomeHandler(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }
        public async Task HandleAsync(DeleteIncome command)
        {
            await _incomeService.DeleteIncomeAsync(command.Id);
        }
    }
}
