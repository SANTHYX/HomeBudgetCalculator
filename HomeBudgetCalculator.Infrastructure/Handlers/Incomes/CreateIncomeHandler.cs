﻿using HomeBudgetCalculator.Infrastructure.Commands.IncomeCommands;
using HomeBudgetCalculator.Infrastructure.Handlers.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Handlers.Incomes
{
    public class CreateIncomeHandler : ICommandHandler<CreateIncome>
    {
        private readonly IIncomeService _incomeService;

        public CreateIncomeHandler(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }
        public async Task HandleAsync(CreateIncome command)
        {
            await _incomeService.AddIncomeAsync(command.BudgetId, command.Title, command.Value,
                command.Date);
        }
    }
}
