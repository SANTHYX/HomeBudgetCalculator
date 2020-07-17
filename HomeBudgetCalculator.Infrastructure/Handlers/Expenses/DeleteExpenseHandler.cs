using HomeBudgetCalculator.Infrastructure.Commands.ExpenseCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Handlers.Expenses
{
    public class DeleteExpenseHandler : ICommandHandler<DeleteExpense>
    {
        private readonly IExpenseService _expenseService;

        public DeleteExpenseHandler(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
        public async Task HandleAsync(DeleteExpense command)
        {
            await _expenseService.DeleteExpenseAsync(command.Id);
        }
    }
}
