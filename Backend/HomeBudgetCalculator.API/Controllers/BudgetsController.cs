using System.Threading.Tasks;
using HomeBudgetCalculator.Infrastructure.Commands.BudgetCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudgetCalculator.API.Controllers
{
    [Authorize(Policy = "AplicationPolicy")]
    [Route("[controller]")]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        private readonly IBudgetService _budgetService;
        private readonly ICommandDispatcher _commandDispatcher;

        public BudgetsController(IBudgetService budgetService, ICommandDispatcher commandDispatcher)
        {
            _budgetService = budgetService;
            _commandDispatcher = commandDispatcher;
        }

        // POST api/Budgets
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InitializeBudget command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }

        // PUT api/Budgets
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateBudget command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }
    }
}
