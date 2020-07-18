using System;

namespace HomeBudgetCalculator.Infrastructure.DTO
{
    public class IncomeDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }
    }
}
