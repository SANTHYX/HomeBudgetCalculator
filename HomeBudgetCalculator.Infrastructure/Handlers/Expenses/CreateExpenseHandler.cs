using HomeBudgetCalculator.Infrastructure.Commands.ExpenseCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Handlers.Expenses
{
    public class CreateExpenseHandler : ICommandHandler<CreateExpense>
    {
        private readonly IExpenseService _expenseService;

        public CreateExpenseHandler(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
        public async Task HandleAsync(CreateExpense command)
        {
            await _expenseService.AddExpenseAsync(command.BudgetId, command.Title, 
                command.Value, command.Date);
        }
    }
}
