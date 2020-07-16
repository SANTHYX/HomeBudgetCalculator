using HomeBudgetCalculator.Infrastructure.Commands.Interfaces;

namespace HomeBudgetCalculator.Infrastructure.Commands.UserCommands
{
    public class UpdateUser : ICommand
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
