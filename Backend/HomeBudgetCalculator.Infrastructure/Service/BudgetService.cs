using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.Exceptions;
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
        private readonly IExpenseRepository _expenseRepository;
        private readonly IIncomeRepository _incomeRepository;

        public BudgetService(IUserRepository userRepository, IBudgetRepository budgetRepository,
            IExpenseRepository expenseRepository, IIncomeRepository incomeRepository)
        {
            _userRepository = userRepository;
            _budgetRepository = budgetRepository;
            _expenseRepository = expenseRepository;
            _incomeRepository = incomeRepository;
        }
        public async Task InitializeBudgetAsync(string login)
        {
            if(!_userRepository.IsUserExist(login))
            {
                throw new ServiceExceptions(ServiceErrorCodes.UserNotExist, 
                    "Cannot relate budget with user that doesn't exist");
            }

            var user = await _userRepository.GetAsync(login);
            await _budgetRepository.AddAsync(new Budget(user.Id));
            await _userRepository.UpdateAsync(user);
        }

        public async Task UpdateBudgetAsync(Guid id)
        {
            if (!_budgetRepository.IsBudgetExist(id))
            {
                throw new ServiceExceptions(ServiceErrorCodes.BudgetNotExist, 
                    "Budget object not exist");
            }

            var budget = await _budgetRepository.GetAsync(id);
            budget.SetTotalIncome(_incomeRepository.CalculateTotalIncome(id));
            budget.SetTotalExpense(_expenseRepository.CalculateTotalExpense(id));
            budget.SetBudgetAmount(budget.TotalIncome - budget.TotalExpense);
            await _budgetRepository.UpdateAsync(budget);
        }
    }
}
