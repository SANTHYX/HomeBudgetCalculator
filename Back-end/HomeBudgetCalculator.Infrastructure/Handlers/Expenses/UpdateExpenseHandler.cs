using HomeBudgetCalculator.Infrastructure.Commands.ExpenseCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Handlers.Expenses
{
    public class UpdateExpenseHandler : ICommandHandler<UpdateExpense>
    {
        private readonly IExpenseService _expenseService;

        public UpdateExpenseHandler(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
        public async Task HandleAsync(UpdateExpense command)
        {
            await _expenseService.UpdateExpenseAsync(command.Id, command.Title, 
                command.Value, command.Date);
        }
    }
}
