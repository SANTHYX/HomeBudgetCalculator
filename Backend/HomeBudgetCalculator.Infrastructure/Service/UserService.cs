using AutoMapper;
using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.DTO;
using HomeBudgetCalculator.Infrastructure.Exceptions;
using HomeBudgetCalculator.Infrastructure.Extensions;
using HomeBudgetCalculator.Infrastructure.JWT.Interfaces;
using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBudgetRepository _budgetRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IBudgetRepository budgetRepository, 
            IEncrypter encrypter, IMapper mapper)
        {
            _userRepository = userRepository;
            _budgetRepository = budgetRepository;
            _encrypter = encrypter;
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
                throw new ServiceExceptions(ServiceErrorCodes.UserExist, 
                    $"User with this login: {login} already exist");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            await _userRepository.AddAsync(new User(firstName, lastName, login, hash, salt, email));
        }

        public async Task SignIn(string login, string password)
        {
            if (!_userRepository.IsUserExist(login))
            {
                throw new ServiceExceptions(ServiceErrorCodes.InvalidCredentials,
                    $"Invalid Credentials");
            }

            var user = await _userRepository.GetAsync(login);
            var hash = _encrypter.GetHash(password, user.Salt);

            if (user.Password == hash)
            {
                return;
            }
            else
                throw new ServiceExceptions(ServiceErrorCodes.InvalidCredentials,
                    $"Invalid Credentials");
        }

        public async Task UpdateUserAsync(string login, string password, string email)
        {
            if (!_userRepository.IsUserExist(login))
            {
                throw new ServiceExceptions(ServiceErrorCodes.UserNotExist, 
                    $"User with login: {login} don't exist");
            }

            var user = await _userRepository.GetAsync(login);
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user.SetPassword(hash, salt);
            user.SetEmail(email);
            await _userRepository.UpdateAsync(user);
        }
    }
}
