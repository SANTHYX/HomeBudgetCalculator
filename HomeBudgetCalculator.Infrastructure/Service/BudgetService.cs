using AutoMapper;
using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.Extensions;
using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Service
{
    public class BudgetService : IBudgetService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBudgetRepository _budgetRepository;

        public BudgetService(IUserRepository userRepository, IBudgetRepository budgetRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _budgetRepository = budgetRepository;
        }
        public async Task CreateBudgetAsync(string login)
        {
            if(!_userRepository.IsUserExistAsync(login))
            {
                throw new Exception("Cannot relate budget with user that doesn't exist");
            }

            var user = _userRepository.GetAsync(login);
            await _budgetRepository.AddAsync(new Budget(user.Id));
            await _userRepository.UpdateAsync(user);
        }

        public async Task UpdateBudgetAsync(Guid id, decimal budgetAmount, decimal totalIncome, decimal totalExpense)
        {
            if (!_budgetRepository.IsBudgetExistAsync(id))
            {
                throw new Exception("Budget not exist");
            }

            var budget = _budgetRepository.GetAsync(id);
            budget.SetBudgetAmount(budgetAmount);
            budget.SetTotalIncome(totalIncome);
            budget.SetTotalExpense(totalExpense);

            await _budgetRepository.UpdateAsync(budget);
        }
    }
}
