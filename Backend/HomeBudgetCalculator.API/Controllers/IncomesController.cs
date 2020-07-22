using System.Threading.Tasks;
using HomeBudgetCalculator.Infrastructure.Commands.IncomeCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudgetCalculator.API.Controllers
{
    [Authorize(Policy = "AplicationPolicy")]
    [Route("[controller]")]
    [ApiController]
    public class IncomesController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public IncomesController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        // POST api/Incomes/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddIncome command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }

        // PUT api/Incomes/
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateIncome command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }

        // DELETE api/Incomes/
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteIncome command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }
    }
}
