using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.EntityFramework;
using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public IQueryable<User> GetAll()
            => _context.Users.AsQueryable();

        public async Task<User> GetAsync(string login)
            => await _context.Users.Include(x => x.Budget).FirstOrDefaultAsync(z => z.Login == login);

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
