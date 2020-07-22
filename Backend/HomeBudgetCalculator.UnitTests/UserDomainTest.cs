using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Core.Exceptions;
using Moq;
using NUnit.Framework;

namespace HomeBudgetCalculator.UnitTests
{
    [TestFixture]
    public class UserDomainTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SetFirstName_method_thorws_exception_when_value_is_empty_or_whitespace()
        {
            var user = new Mock<User>();
            var testvalue = "";
            var expected = "Name cannot be empty";

            var ex = Assert.Throws<DomainExceptions>(() => user.Object.SetFirstName(testvalue));
            var ex2 = Assert.Throws<DomainExceptions>(() => user.Object.SetFirstName("      "));
            Assert.AreEqual(expected, ex.Message);
            Assert.AreEqual(expected, ex2.Message);
        }

        [Test]
        public void SetFirstName_method_should_pass_if_string_is_not_empty()
        {
            var user = new Mock<User>();
            var testvalue = "Jan";
            var expected = "Jan";

            user.Object.SetFirstName(testvalue);
            Assert.AreEqual(expected, user.Object.FirstName);
        }

        [Test]
        public void SetLogin_method_thorws_exception_when_value_is_empty_or_whitespace()
        {
            var user = new Mock<User>();
            var testvalue = "";
            var expected = "Login cannot be empty";

            var ex = Assert.Throws<DomainExceptions>(() => user.Object.SetLogin(testvalue));
            var ex2 = Assert.Throws<DomainExceptions>(() => user.Object.SetLogin("      "));
            Assert.AreEqual(expected, ex.Message);
            Assert.AreEqual(expected, ex2.Message);
        }

        [Test]
        public void SetLogin_method_thorws_exception_when_value_is_shorter_than_6_chars()
        {
            var user = new Mock<User>();
            var testvalue = "axc!2";
            var expected = "Login in this form is too weak";

            var ex = Assert.Throws<DomainExceptions>(() => user.Object.SetLogin(testvalue));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetLogin_method_thorws_exception_when_value_is_longer_than_6chars_but_without_bigChar()
        {
            var user = new Mock<User>();
            var testvalue = "axcda7cx";
            var expected = "Login in this form is too weak";

            var ex = Assert.Throws<DomainExceptions>(() => user.Object.SetLogin(testvalue));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetLogin_method_thorws_exception_when_value_is_longer_than_6chars_but_without_number()
        {
            var user = new Mock<User>();
            var testvalue = "axcsdaxXvcx";
            var expected = "Login in this form is too weak";

            var ex = Assert.Throws<DomainExceptions>(() => user.Object.SetLogin(testvalue));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetLogin_method_pass_if_value_contain_more_than_6_chars_including_number_and_one_big_letter_one_smalleter()
        {
            var user = new Mock<User>();
            var testvalue = "axcAdaxfv!2cx";
            var expected = "axcAdaxfv!2cx";

            user.Object.SetLogin(testvalue);
            Assert.AreEqual(expected, user.Object.Login);
        }

        [Test]
        public void SetLastName_method_thorws_exception_when_value_is_empty_or_whitespace()
        {
            var user = new Mock<User>();
            var testvalue = "";
            var expected = "Name cannot be empty";

            var ex = Assert.Throws<DomainExceptions>(() => user.Object.SetLastName(testvalue));
            var ex2 = Assert.Throws<DomainExceptions>(() => user.Object.SetLastName("      "));
            Assert.AreEqual(expected, ex.Message);
            Assert.AreEqual(expected, ex2.Message);
        }

        [Test]
        public void SetLastName_method_should_pass_if_string_is_not_empty()
        {
            var user = new Mock<User>();
            var testvalue = "Kowal";
            var expected = "Kowal";

            user.Object.SetLastName(testvalue);
            Assert.AreEqual(expected, user.Object.LastName);
        }

        [Test]
        public void SetPassword_method_throws_exception_if_password_is_empty_string()
        {
            var user = new Mock<User>();
            var testvalue = "";
            var expected = "Password cannot be empty";

            var ex = Assert.Throws<DomainExceptions>(() => user.Object.SetPassword(testvalue, "xcxcxcxcewqrqwdwq4332532esad"));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetPassword_method_throws_exception_if_salt_is_empty_string()
        {
            var user = new Mock<User>();
            var testvalue = "adsdadas";
            var expected = "Salt cannot be empty";

            var ex = Assert.Throws<DomainExceptions>(() => user.Object.SetPassword(testvalue, ""));
            Assert.AreEqual(expected, ex.Message);
        }
        [Test]
        public void SetPassword_method_throws_exception_if_password_dont_have_more_chars_than_4()
        {
            var user = new Mock<User>();
            var testvalue = "sxS";
            var expected = "Password is weak";

            var ex = Assert.Throws<DomainExceptions>(() => user.Object.SetPassword(testvalue, "d3213ewqewqewqewqewqecz"));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetPassword_method_throws_exception_if_password_dont_contain_lower_case_char()
        {
            var user = new Mock<User>();
            var testvalue = "ASSCCXZWR1TS";
            var expected = "Password is weak";

            var ex = Assert.Throws<DomainExceptions>(() => user.Object.SetPassword(testvalue, "d3213ewqewqewqewqewqecz"));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetPassword_method_throws_exception_if_password_dont_contain_upper_case_leter()
        {
            var user = new Mock<User>();
            var testvalue = "aaaaaaaaae5qwewq";
            var expected = "Password is weak";

            var ex = Assert.Throws<DomainExceptions>(() => user.Object.SetPassword(testvalue, "d3213ewqewqewqewqewqecz"));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetPassword_method_throws_exception_if_password_dont_contain_atleast_one_number()
        {
            var user = new Mock<User>();
            var testvalue = "aaaaaaaAaeqwewq";
            var expected = "Password is weak";

            var ex = Assert.Throws<DomainExceptions>(() => user.Object.SetPassword(testvalue, "d3213ewqewqewqewqewqecz"));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetPassword_method_pass_if_values_that_should_be_correct_are_given()
        {
            var user = new Mock<User>();
            var testvalue = "aaaaa2aAaeqwewq";
            var expected = "aaaaa2aAaeqwewq";

            user.Object.SetPassword(testvalue, "d3213ewqewqewqewqewqecz");
            Assert.AreEqual(expected, user.Object.Password);
        }

        [Test]
        public void SetEmail_method_should_throw_exception_if_Email_body_is_wrong()
        {
            var user = new Mock<User>();
            var testvalue = "aaaaaaaAaeqwewq.com";
            var expected = "Invalid Email string";

            var ex = Assert.Throws<DomainExceptions>(() => user.Object.SetEmail(testvalue));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetEmail_method_should_throw_exception_if_string_is_empty()
        {
            var user = new Mock<User>();
            var testvalue = "";
            var expected = "Email cannot be empty";

            var ex = Assert.Throws<DomainExceptions>(() => user.Object.SetEmail(testvalue));
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void SetEmail_method_should_pass_if_body_is_correct_and_not_empty()
        {
            var user = new Mock<User>();
            var testvalue = "micha³ekPolski23@gmail.com";
            var expected = "micha³ekPolski23@gmail.com";

            user.Object.SetEmail(testvalue);
            Assert.AreEqual(expected, user.Object.Email);
        }
    }
}