using HomeBudgetCalculator.Infrastructure.Commands.IncomeCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Handlers.Incomes
{
    public class UpdateIncomeHandler : ICommandHandler<UpdateIncome>
    {
        private readonly IIncomeService _incomeService;

        public UpdateIncomeHandler(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }
        public async Task HandleAsync(UpdateIncome command)
        {
            await _incomeService.UpdateIncomeAsync(command.Id, command.Title, command.Value, 
                command.Date);
        }
    }
}
