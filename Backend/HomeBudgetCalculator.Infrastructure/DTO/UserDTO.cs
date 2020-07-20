using System;

namespace HomeBudgetCalculator.Infrastructure.DTO
{
    public class UserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public BudgetDTO Budget { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
