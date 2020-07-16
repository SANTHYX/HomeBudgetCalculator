using System;

namespace HomeBudgetCalculator.Core.Domains
{
    public class Income
    {
        public Guid Id { get; protected set; }

        public string Title { get; protected set; }

        public decimal Value { get; protected set; }

        public DateTime Date { get; protected set; }

        public Income(string title, decimal value, DateTime date)
        {
            Id = Guid.NewGuid();
            SetTitle(title);
            SetValue(value);
            SetDate(date);
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new Exception("Title cannot be empty");
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
                throw new Exception("Value cannot be empty");
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
                throw new Exception("Wrong value of date");
            }
            if (Date == date)
            {
                return;
            }

            Date = date;
        }
    }
}
