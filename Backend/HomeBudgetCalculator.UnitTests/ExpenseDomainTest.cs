using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Core.Exceptions;
using Moq;
using NUnit.Framework;
using System;

namespace HomeBudgetCalculator.UnitTests
{
    [TestFixture]
    public class ExpenseDomainTest
    {
        [Test]
        public void SetTitle_method_throws_exception_when_value_is_empty()
        {
            var expense = new Mock<Expense>();
            var testvalue = " ";
            var expected = "Title cannot be empty";

            var ex = Assert.Throws<DomainExceptions>(() => expense.Object.SetTitle(testvalue));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetTitle_method_pass_if_value_is_not_empty()
        {
            var expense = new Mock<Expense>();
            var testvalue = "renta";
            var expected = "renta";

            expense.Object.SetTitle(testvalue);
            Assert.AreEqual(expected, expense.Object.Title);
        }

        [Test]
        public void SetValue_method_throws_exception_when_value_is_0()
        {
            var expense = new Mock<Expense>();
            var testvalue = 0;
            var expected = "Value cannot be empty";

            var ex = Assert.Throws<DomainExceptions>(() => expense.Object.SetValue(testvalue));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetValue_method_throws_exception_when_value_is_less_than_0()
        {
            var expense = new Mock<Expense>();
            var testvalue = -1;
            var expected = "Value cannot be empty";

            var ex = Assert.Throws<DomainExceptions>(() => expense.Object.SetValue(testvalue));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetValue_method_pass_if_value_is_higher_than_0()
        {
            var expense = new Mock<Expense>();
            var testvalue = 1;
            var expected = 1;

            expense.Object.SetValue(testvalue);
            Assert.AreEqual(expected, expense.Object.Value);
        }

        [Test]
        public void SetDate_method_throws_exception_where_value_is_too_far_than_actual_date()
        {
            var expense = new Mock<Expense>();
            var testvalue = DateTime.MinValue;
            var expected = "Wrong value of date";

            var ex = Assert.Throws<DomainExceptions>(() => expense.Object.SetDate(testvalue));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetDate_method_pass_when_value_date_is_right_constructed()
        {
            var expense = new Mock<Expense>();
            var testvalue = DateTime.Today;
            var expected = DateTime.Today;

            expense.Object.SetDate(testvalue);
            Assert.AreEqual(expected, expense.Object.Date);
        }

        [Test]
        public void SetBudgetId_throws_exception_where_value_is_empty()
        {
            var expense = new Mock<Expense>();
            var testvalue = Guid.Empty;
            var expected = "BudgetId cannot be empty if u want to relate entities: Budget <> Expense";

            var ex = Assert.Throws<DomainExceptions>(() => expense.Object.SetBudgetId(testvalue));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetTotalExpense_pass_if_guid_is_correct()
        {
            var expense = new Mock<Expense>();
            var testvalue = "98dac9d2-b9d2-4a44-9273-7439ca842a98";
            var expected = Guid.Parse("98dac9d2-b9d2-4a44-9273-7439ca842a98");

            expense.Object.SetBudgetId(Guid.Parse(testvalue));
            Assert.AreEqual(expected, expense.Object.BudgetId);
        }

    }
}
