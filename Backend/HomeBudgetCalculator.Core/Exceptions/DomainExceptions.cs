using System;

namespace HomeBudgetCalculator.Core.Exceptions
{
    public class DomainExceptions : ApplicationExceptions
    {
        public DomainExceptions()
        {
        }

        public DomainExceptions(string code) : base(code)
        {
           
        }

        public DomainExceptions(string message, params object[] args)
            : base(string.Empty, message, args)
        {

        }

        public DomainExceptions(string code, string message, params object[] args)
            : base(null, string.Empty, message, args)
        {

        }

        public DomainExceptions(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args)
        {

        }

        public DomainExceptions(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            
        }
    }
}
