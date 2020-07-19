using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace HomeBudgetCalculator.Infrastructure.Extensions
{
    public static class UserRepositoryExtension
    {
        public static bool IsUserExist(this IUserRepository userRepository, string login)
        {
            var userExist = userRepository.GetAll().Where(x => x.Login == login).Any();

            if (userExist)
            {
                return true;
            }

            return false;
        }
    }
}
