using System;
using System.Threading.Tasks;
using HomeBudgetCalculator.Infrastructure.Commands.UserCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeBudgetCalculator.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private ICommandDispatcher _commandDispatcher;

        public SignInController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        // POST api/<SignInController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SignUpUser command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok(command.Token);
        }
    }
}
