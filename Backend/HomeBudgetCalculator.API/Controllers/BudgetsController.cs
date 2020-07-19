using System.Collections.Generic;
using System.Threading.Tasks;
using HomeBudgetCalculator.Infrastructure.Commands.BudgetCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeBudgetCalculator.API.Controllers
{
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
        // GET: api/Budgets/
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Budgets/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Budgets
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

        // DELETE api/Budgets/
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
