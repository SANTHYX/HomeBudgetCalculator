using System.Threading.Tasks;
using HomeBudgetCalculator.Infrastructure.Commands.UserCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        // POST SignIn/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SignUpUser command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok(command.Token);
        }
    }
}
