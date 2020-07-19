using System.Collections.Generic;
using System.Threading.Tasks;
using HomeBudgetCalculator.Infrastructure.Commands.ExpenseCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeBudgetCalculator.API.Controllers
{
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
        // GET: api/Expenses/
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Expenses/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteExpense command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }
    }
}
