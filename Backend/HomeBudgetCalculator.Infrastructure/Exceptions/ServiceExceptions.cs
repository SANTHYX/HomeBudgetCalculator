using System;

namespace HomeBudgetCalculator.Infrastructure.Exceptions
{
    public class ServiceExceptions : Core.Exceptions.ApplicationExceptions
    {
        public ServiceExceptions(string code) : base(code)
        {

        }

        public ServiceExceptions(string message, params object[] args)
            : base(string.Empty, message, args)
        {

        }

        public ServiceExceptions(string code, string message, params object[] args)
            : base(null, string.Empty, message, args)
        {

        }

        public ServiceExceptions(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args)
        {

        }

        public ServiceExceptions(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {

        }
    }
}
