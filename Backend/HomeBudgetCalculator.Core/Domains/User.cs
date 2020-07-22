using HomeBudgetCalculator.Core.Exceptions;
using HomeBudgetCalculator.Core.Extension;
using System;

namespace HomeBudgetCalculator.Core.Domains
{
    public class User
    {
        public Guid Id { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public string Login { get; protected set; }

        public string Password { get; protected set; }

        public string Salt { get; protected set; }

        public string Email { get; protected set; }

        public Budget Budget { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        protected User()
        {

        }

        public User(string firstName, string lastName, string login, 
            string password, string salt, string email)
        {
            Id = Guid.NewGuid();
            SetFirstName(firstName);
            SetLastName(lastName);
            SetLogin(login);
            SetPassword(password, salt);
            SetEmail(email);
            CreatedAt = DateTime.Now;
        }

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new DomainExceptions(DomainErrorCodes.InvalidFirstName, 
                    "Name cannot be empty");
            }
            if (FirstName == firstName)
            {
                return;
            }

            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new DomainExceptions(DomainErrorCodes.InvalidLastName, 
                    "Name cannot be empty");
            }
            if (LastName == lastName)
            {
                return;
            }

            LastName = lastName;
        }
        
        public void SetLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new DomainExceptions(DomainErrorCodes.InvalidLogin, 
                    "Login cannot be empty");
            }
            if (!login.IsLoginValid())
            {
                throw new DomainExceptions(DomainErrorCodes.InvalidLogin, 
                    "Login in this form is too weak");
            }
            if (Login == login)
            {
                return;
            }

            Login = login;
        }

        public void SetPassword(string password, string salt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new DomainExceptions(DomainErrorCodes.InvalidPassword, 
                    "Password cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new DomainExceptions(DomainErrorCodes.InvalidPassword,
                    "Salt cannot be empty");
            }
            if (!password.IsPasswordValid())
            {
                throw new DomainExceptions(DomainErrorCodes.InvalidPassword, 
                    "Password is weak");
            }
            if (Password == password)
            {
                return;
            }

            Password = password;
            Salt = salt;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainExceptions(DomainErrorCodes.InvalidEmail, 
                    "Email cannot be empty");
            }
            if (!email.IsEmailValid())
            {
                throw new DomainExceptions(DomainErrorCodes.InvalidEmail, 
                    "Invalid Email string");
            }
            if (Email == email)
            {
                return;
            }

            Email = email;
        }
    }
}
