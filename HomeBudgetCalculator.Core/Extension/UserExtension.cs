using System.Text.RegularExpressions;

namespace HomeBudgetCalculator.Core.Extension
{
    public static class UserExtension
    {
        private static readonly Regex passwordScheme = new Regex(@"^(?=.{4,})(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?!.*\s).*$");
        private static readonly Regex loginScheme = new Regex(@"^(?=.{6,})(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).*$");
        private static readonly Regex emailScheme = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public static bool IsLoginValid(this string value) 
            => loginScheme.IsMatch(value);

        public static bool IsPasswordValid(this string value)
            => passwordScheme.IsMatch(value);

        public static bool IsEmailValid(this string value)
            => emailScheme.IsMatch(value);
    }
}
