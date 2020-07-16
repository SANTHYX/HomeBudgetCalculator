﻿using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Extensions
{
    public static class BudgetExtensions
    {
        public static bool IsBudgetExistAsync(this IBudgetRepository budgetRepository, Guid id)
        {
            var budget = budgetRepository.GetAllAsync();
            var budgetExist = budget.Where(x => x.Id == id).Any();

            if (budgetExist)
            {
                return true;
            }

            return false;
        }
    }
}
