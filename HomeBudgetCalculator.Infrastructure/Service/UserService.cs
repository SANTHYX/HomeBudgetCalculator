using AutoMapper;
using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.DTO;
using HomeBudgetCalculator.Infrastructure.Extensions;
using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IBudgetRepository budgetRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _budgetRepository = budgetRepository;
            _mapper = mapper;
        }

        public IEnumerable<UserDTO> BrowseUsersAsync()
        {
            var users = _userRepository.GetAll();

            return _mapper.ProjectTo<UserDTO>(users).ToList();
        }

        public async Task<UserDTO> GetUserAsync(string login)
        {
            var user = await _userRepository.GetAsync(login);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task RegisterUserAsync(string firstName, string lastName, string login, string password,
            string email)
        {
            if (_userRepository.IsUserExist(login))
            {
                throw new Exception($"User with this login: {login} already exist");
            }

            await _userRepository.AddAsync(new User(firstName, lastName, login, password, email));
        }
        /*UpdateUserAsync wymaga przemyślenia*/
        public async Task UpdateUserAsync(string login, string password, string email)
        {
            if (!_userRepository.IsUserExist(login))
            {
                throw new Exception($"User with login: {login} don't exist");
            }

            var user = await _userRepository.GetAsync(login);
            user.SetPassword(password);
            user.SetEmail(email);

            await _userRepository.UpdateAsync(user);
        }
    }
}
