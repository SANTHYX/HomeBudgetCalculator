using HomeBudgetCalculator.Core.Domains;

namespace HomeBudgetCalculator.Infrastructure.DTO
{
    public class UserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public BudgetDTO Budget { get; set; }
    }
}
