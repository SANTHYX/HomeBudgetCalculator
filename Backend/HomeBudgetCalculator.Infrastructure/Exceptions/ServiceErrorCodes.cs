namespace HomeBudgetCalculator.Infrastructure.Exceptions
{
    public class ServiceErrorCodes
    {
        public static string BudgetNotExist => "budget_not_exist";

        public static string ExpenseNotExist => "expense_not_exist";

        public static string UserNotExist => "user_not_exist";

        public static string UserExist => "user_exist";

        public static string IncomeNotExist => "income_not_exist";

        public static string InvalidCredentials => "invalid_credentials";
    }
}
