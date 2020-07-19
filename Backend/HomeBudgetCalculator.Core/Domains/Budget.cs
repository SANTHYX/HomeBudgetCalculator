using HomeBudgetCalculator.Core.Exceptions;
using System;
using System.Collections.Generic;

namespace HomeBudgetCalculator.Core.Domains
{
    public class Budget
    {
        public Guid Id { get; protected set; }

        public decimal BudgetAmount { get; protected set; }

        public decimal TotalIncome { get; protected set; }

        public decimal TotalExpense { get; protected set; }

        public Guid UserId { get; protected set; }

        public User User { get; protected set; }

        public IEnumerable<Expense> Expenses { get; protected set; }

        public IEnumerable<Income> Incomes { get; protected set; }

        public Budget(Guid userId)
        {
            Id = Guid.NewGuid();
            BudgetAmount = TotalExpense = TotalIncome = 0;
            SetUserId(userId);
        }

        public Budget(decimal budgetAmount, decimal totalIncome, decimal totalExpense)
        {
            SetBudgetAmount(budgetAmount);
            SetTotalIncome(totalIncome);
            SetTotalExpense(totalExpense);
        }

        public void SetBudgetAmount(decimal budgetAmount)
        {
            BudgetAmount = budgetAmount;
        }

        public void SetTotalIncome(decimal totalIncome)
        {
            if (totalIncome < 0)
            {
                throw new DomainExceptions(DomainErrorCodes.InvalidTotalIncome, 
                    "Income cannot be less than zero");
            }

            TotalIncome = totalIncome;
        }

        public void SetTotalExpense(decimal totalExpense)
        {
            if (totalExpense < 0)
            {
                throw new DomainExceptions(DomainErrorCodes.InvalidTotalExpense, 
                    "Income cannot be less than zero");
            }

            TotalExpense = totalExpense;
        }

        public void SetUserId(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new DomainExceptions(DomainErrorCodes.InvalidUserId, 
                    "UserId cannot be empty if u want to relate entities: User <> Budget");
            }
            UserId = userId;
        }
    }
}
