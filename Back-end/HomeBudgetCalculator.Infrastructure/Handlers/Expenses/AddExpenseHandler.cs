using HomeBudgetCalculator.Infrastructure.Commands.ExpenseCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Handlers.Expenses
{
    public class AddExpenseHandler : ICommandHandler<AddExpense>
    {
        private readonly IExpenseService _expenseService;

        public AddExpenseHandler(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
        public async Task HandleAsync(AddExpense command)
        {
            await _expenseService.AddExpenseAsync(command.BudgetId, command.Title, 
                command.Value, command.Date);
        }
    }
}
