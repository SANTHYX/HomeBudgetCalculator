using System.Threading.Tasks;
using HomeBudgetCalculator.Infrastructure.Commands.UserCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudgetCalculator.Infrastructure.Controllers
{
    [Authorize(Policy = "AplicationPolicy")]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICommandDispatcher _commandDispatcher;

        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher)
        {
            _userService = userService;
            _commandDispatcher = commandDispatcher;
        }
        // GET: api/Users/GetAll/
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var users = _userService.BrowseUsersAsync();

            return Ok(users);
        }

        // GET: api/Users/{login}
        [HttpGet("{login}", Name = "Get")]
        public async Task<IActionResult> Get(string login)
        {
            var user = await _userService.GetUserAsync(login);

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUser command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }

        // PUT: api/Users/
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUser command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }
    }
}
