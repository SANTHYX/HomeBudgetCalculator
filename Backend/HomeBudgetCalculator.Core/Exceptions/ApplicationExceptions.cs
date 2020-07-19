using System;

namespace HomeBudgetCalculator.Core.Exceptions
{
    public abstract class ApplicationExceptions : Exception
    {
        public string Code { get; }

        public ApplicationExceptions(string code)
        {
            Code = code;
        }

        public ApplicationExceptions(string message, params object[] args) 
            : this(string.Empty, message, args)
        {

        }

        public ApplicationExceptions(string code, string message, params object[] args) 
            : this(null, string.Empty, message, args)
        {

        }

        public ApplicationExceptions(Exception innerException, string message, params object[] args) 
            : this(innerException, string.Empty, message, args)
        {

        }

        public ApplicationExceptions(Exception innerException, string code, string message, params object[] args) 
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
