using HomeBudgetCalculator.Infrastructure.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBudgetCalculator.Infrastructure.Commands.IncomeCommands
{
    public class DeleteIncome : ICommand
    {
        public Guid Id { get; set; }
    }
}
