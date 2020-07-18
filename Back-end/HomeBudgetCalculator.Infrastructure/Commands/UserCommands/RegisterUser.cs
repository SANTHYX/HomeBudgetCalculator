using HomeBudgetCalculator.Infrastructure.Commands.Interfaces;

namespace HomeBudgetCalculator.Infrastructure.Commands.UserCommands
{
    public class RegisterUser : ICommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
