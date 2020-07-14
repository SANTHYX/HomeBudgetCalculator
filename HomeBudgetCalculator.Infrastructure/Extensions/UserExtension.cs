using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Extensions
{
    public static class UserExtension
    {
        public async static Task<bool> UserAlreadyExist(this IUserRepository userRepository, string login)
        {
            var user =  await userRepository.GetAllAsync();
            var query = user.Where(x => x.Login == login);

            if (query.Any())
            {
                return true;
            }

            return false;
        }
    }
}
