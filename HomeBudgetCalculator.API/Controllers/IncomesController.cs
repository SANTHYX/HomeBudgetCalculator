using System.Collections.Generic;
using System.Threading.Tasks;
using HomeBudgetCalculator.Infrastructure.Commands.IncomeCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeBudgetCalculator.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IncomesController : ControllerBase
    {
        private readonly IIncomeService _incomeService;
        private readonly ICommandDispatcher _commandDispatcher;

        public IncomesController(IIncomeService incomeService, ICommandDispatcher commandDispatcher)
        {
            _incomeService = incomeService;
            _commandDispatcher = commandDispatcher;
        }

        // GET: api/<IncomesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<IncomesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<IncomesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateIncome command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }

        // PUT api/<IncomesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateIncome command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }

        // DELETE api/<IncomesController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteIncome command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }
    }
}
