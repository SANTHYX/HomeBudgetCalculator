using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.EntityFramework.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository : IRepository, ISqlRepository
    {
        Task AddAsync(User user);

        Task UpdateAsync(User user);

        Task DeleteAsync(User user);

        Task<User> GetAsync(string login);

        IQueryable<User> GetAll();
    }
}
