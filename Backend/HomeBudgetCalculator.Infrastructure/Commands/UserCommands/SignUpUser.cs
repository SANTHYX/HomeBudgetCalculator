using HomeBudgetCalculator.Infrastructure.Commands.Interfaces;
using System;

namespace HomeBudgetCalculator.Infrastructure.Commands.UserCommands
{
    public class SignUpUser : ICommand
    {
        public Guid TokenId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}
