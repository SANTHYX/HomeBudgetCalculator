namespace HomeBudgetCalculator.Core.Exceptions
{
    public static class DomainErrorCodes
    {
        public static string InvalidLogin => "invalid_login";

        public static string InvalidPassword => "invalid_password";

        public static string InvalidFirstName => "invalid_firstname";

        public static string InvalidLastName => "invalid lastname;";

        public static string InvalidEmail => "invalid email";

        public static string InvalidTotalIncome => "invalid_totalIncome";

        public static string InvalidTotalExpense => "invalid_totalExpense";

        public static string InvalidUserId => "invalid_userId";

        public static string InvalidTitle => "invalid_title";

        public static string InvalidValue => "invalid_value";

        public static string InvalidDate => "invalid_date";

        public static string InvalidBudgetId => "invalid_budgetId";
    }
}
