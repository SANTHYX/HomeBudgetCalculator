using HomeBudgetCalculator.Core.Exceptions;
using System;

namespace HomeBudgetCalculator.Core.Domains
{
    public class Income
    {
        public Guid Id { get; protected set; }

        public string Title { get; protected set; }

        public decimal Value { get; protected set; }

        public DateTime Date { get; protected set; }

        public Guid BudgetId { get; protected set; }

        public Budget Budget { get; protected set; }

        public Income(string title, decimal value, DateTime date, Guid budgetId)
        {
            Id = Guid.NewGuid();
            SetTitle(title);
            SetValue(value);
            SetDate(date);
            SetBudgetId(budgetId);
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new DomainExceptions(DomainErrorCodes.InvalidTitle, 
                    "Title cannot be empty");
            }
            if (Title == title)
            {
                return;
            }

            Title = title;
        }

        public void SetValue(decimal value)
        {
            if (value == decimal.Zero)
            {
                throw new DomainExceptions(DomainErrorCodes.InvalidValue, 
                    "Value cannot be empty");
            }
            if (Value == value)
            {
                return;
            }

            Value = value;
        }

        public void SetDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                throw new DomainExceptions(DomainErrorCodes.InvalidDate, 
                    "Wrong value of date");
            }
            if (Date == date)
            {
                return;
            }

            Date = date;
        }

        public void SetBudgetId(Guid budgetId)
        {
            if (budgetId == Guid.Empty)
            {
                throw new DomainExceptions(DomainErrorCodes.InvalidBudgetId, 
                    "BudgetId cannot be empty if u want to relate entities: Budget <> Expense");
            }

            BudgetId = budgetId;
        }
    }
}
