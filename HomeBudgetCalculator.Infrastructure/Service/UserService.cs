using AutoMapper;
using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.DTO;
using HomeBudgetCalculator.Infrastructure.Extensions;
using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> BrowseAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetAsync(string login)
        {
            var user = await _userRepository.GetAsync(login);

            return _mapper.Map<User ,UserDTO>(user);
        }

        public async Task RegisterAsync(string firstName, string lastName, string login, string password, string email)
        {
            if(await _userRepository.UserAlreadyExist(login))
            {
                throw new Exception($"User with this login:{login} already exist");
            }

            await _userRepository.AddAsync(new User(firstName, lastName, login, password, email));
        }
    }
}
