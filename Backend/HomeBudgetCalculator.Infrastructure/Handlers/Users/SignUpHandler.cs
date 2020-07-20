using HomeBudgetCalculator.Infrastructure.Commands.UserCommands;
using HomeBudgetCalculator.Infrastructure.Extensions;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.JWT.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Handlers.Users
{
    public class SignUpHandler : ICommandHandler<SignUpUser>
    {
        private readonly IUserService _userService;
        private readonly IJWTHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public SignUpHandler(IUserService userService, IJWTHandler jwtHandler,
        IMemoryCache cache)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }
        public async Task HandleAsync(SignUpUser command)
        {
            await _userService.SignIn(command.Login, command.Password);
            var user = await _userService.GetUserAsync(command.Login);
            var jwt = _jwtHandler.CreateToken(command.Login, user.Email);
            command.Token = jwt.Token;
        }
    }
}
