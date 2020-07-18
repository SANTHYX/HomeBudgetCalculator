using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Extensions
{
    public static class UserExtension
    {
        public static bool IsUserExist(this IUserRepository userRepository, string login)
        {
            var user =  userRepository.GetAll().Where(x => x.Login == login);
            var userExist = user.Any();

            if (userExist)
            {
                return true;
            }

            return false;
        }
    }
}
