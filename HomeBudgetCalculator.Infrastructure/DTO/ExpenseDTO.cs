using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBudgetCalculator.Infrastructure.DTO
{
    public class ExpenseDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }
    }
}
