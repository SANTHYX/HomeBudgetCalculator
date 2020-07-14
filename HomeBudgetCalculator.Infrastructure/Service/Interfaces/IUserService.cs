using HomeBudgetCalculator.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Service.Interfaces
{
    public interface IUserService : IService
    {
        Task <IEnumerable<UserDTO>> BrowseAsync();

        Task<UserDTO> GetAsync(string login);

        Task RegisterAsync(string firstName, string lastName, string login, string password, string email);
    }
}
