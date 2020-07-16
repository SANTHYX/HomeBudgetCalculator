using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Extensions
{
    public static class UserExtension
    {
        public static bool IsUserExistAsync(this IUserRepository userRepository, string login)
        {
            var user =  userRepository.GetAllAsync().Where(x => x.Login == login);
            var userExist = user.Any();

            if (userExist)
            {
                return true;
            }

            return false;
        }
    }
}
