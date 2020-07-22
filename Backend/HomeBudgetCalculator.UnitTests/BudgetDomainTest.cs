using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Core.Exceptions;
using Moq;
using NUnit.Framework;
using System;

namespace HomeBudgetCalculator.UnitTests
{
    [TestFixture]
    public class BudgetDomainTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SetBudgetAmount_method_sets_value()
        {
            var budget = new Mock<Budget>();
            var testvalue = 234;
            var expected = 234;

            budget.Object.SetBudgetAmount(testvalue);
            Assert.AreEqual(expected, budget.Object.BudgetAmount);
        }

        [Test]
        public void SetTotalIncome_throws_exception_where_value_less_than_0()
        {
            var budget = new Mock<Budget>();
            var testvalue = -20;
            var expected = "Income cannot be less than zero";

            var ex = Assert.Throws<DomainExceptions>(() => budget.Object.SetTotalIncome(testvalue));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetTotalIncome_pass_if_values_are_greater_than_0()
        {
            var budget = new Mock<Budget>();
            var testvalue = 20;
            var expected = 20;

            budget.Object.SetTotalIncome(testvalue);
            Assert.AreEqual(expected, budget.Object.TotalIncome);
        }

        [Test]
        public void SetTotalExpense_throws_exception_where_value_less_than_0()
        {
            var budget = new Mock<Budget>();
            var testvalue = -20;
            var expected = "Expense cannot be less than zero";

            var ex = Assert.Throws<DomainExceptions>(() => budget.Object.SetTotalExpense(testvalue));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetTotalExpense_pass_if_values_are_greater_than_0()
        {
            var budget = new Mock<Budget>();
            var testvalue = 20;
            var expected = 20;

            budget.Object.SetTotalExpense(testvalue);
            Assert.AreEqual(expected, budget.Object.TotalExpense);
        }

        [Test]
        public void SetUserId_throws_exception_where_value_is_empty()
        {
            var budget = new Mock<Budget>();
            var testvalue = Guid.Empty;
            var expected = "UserId cannot be empty if u want to relate entities: User <> Budget";

            var ex = Assert.Throws<DomainExceptions>(() => budget.Object.SetUserId(testvalue));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetTotalExpense_pass_if_guid_is_correct()
        {
            var budget = new Mock<Budget>();
            var testvalue = "98dac9d2-b9d2-4a44-9273-7439ca842a98";
            var expected = Guid.Parse("98dac9d2-b9d2-4a44-9273-7439ca842a98");

            budget.Object.SetUserId(Guid.Parse(testvalue));
            Assert.AreEqual(expected, budget.Object.UserId);
        }
    }
}
