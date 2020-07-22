using System.Threading.Tasks;
using HomeBudgetCalculator.Infrastructure.Commands.ExpenseCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudgetCalculator.API.Controllers
{
    [Authorize(Policy = "AplicationPolicy")]
    [Route("[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        private readonly ICommandDispatcher _commandDispatcher;

        public ExpensesController(IExpenseService expenseService, ICommandDispatcher commandDispatcher)
        {
            _expenseService = expenseService;
            _commandDispatcher = commandDispatcher;
        }

        // POST api/Expenses/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddExpense command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }

        // PUT api/Expenses/
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateExpense command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }

        // DELETE api/Expenses/
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteExpense command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }
    }
}
