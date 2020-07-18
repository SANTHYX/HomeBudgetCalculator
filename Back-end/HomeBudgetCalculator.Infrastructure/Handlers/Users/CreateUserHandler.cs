using HomeBudgetCalculator.Infrastructure.Commands.UserCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<RegisterUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(RegisterUser command)
        {
            await _userService.RegisterUserAsync(command.FirstName, command.LastName,
                command.Login, command.Password, command.Email);
        }
    }
}
