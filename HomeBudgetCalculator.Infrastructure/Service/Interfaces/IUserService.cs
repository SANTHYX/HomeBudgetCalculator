using HomeBudgetCalculator.Infrastructure.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Service.Interfaces
{
    public interface IUserService : IService
    {
        IEnumerable<UserDTO> BrowseUsersAsync();

        UserDTO GetUserAsync(string login);

        Task RegisterUserAsync(string firstName, string lastName, string login, string password, string email);

        Task UpdateUserAsync(string login, string password, string email);
    }
}
