using HomeBudgetCalculator.Infrastructure.Commands.UserCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Handlers.Users
{
    public class UpdateUserHandler : ICommandHandler<UpdateUser>
    {
        private readonly IUserService _userService;

        public UpdateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(UpdateUser command)
        {
            await _userService.UpdateUserAsync(command.Login, command.Password, command.Email);
        }
    }
}
