using System;

namespace HomeBudgetCalculator.Core.Exceptions
{
    public abstract class ApplicationExceptions : Exception
    {
        public string Code { get; }

        protected ApplicationExceptions()
        {

        }

        protected ApplicationExceptions(string code)
        {
            Code = code;
        }

        protected ApplicationExceptions(string message, params object[] args) 
            : this(string.Empty, message, args)
        {

        }

        protected ApplicationExceptions(string code, string message, params object[] args) 
            : this(null, string.Empty, message, args)
        {
            Code = code;
        }

        protected ApplicationExceptions(Exception innerException, string message, params object[] args) 
            : this(innerException, string.Empty, message, args)
        {

        }

        protected ApplicationExceptions(Exception innerException, string code, string message, params object[] args) 
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
