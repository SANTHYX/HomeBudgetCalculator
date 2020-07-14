using HomeBudgetCalculator.Infrastructure.Commands.Interface;

namespace HomeBudgetCalculator.Infrastructure.Commands.UserCommands
{
    public class CreateUser : ICommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
