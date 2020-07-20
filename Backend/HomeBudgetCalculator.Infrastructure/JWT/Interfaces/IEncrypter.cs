namespace HomeBudgetCalculator.Infrastructure.JWT.Interfaces
{
    public interface IEncrypter
    {
        string GetSalt(string value);
        string GetHash(string value, string salt);
    }
}
