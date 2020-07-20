using HomeBudgetCalculator.Infrastructure.DTO;

namespace HomeBudgetCalculator.Infrastructure.JWT.Interfaces
{
    public interface IJWTHandler
    {
        JwtDTO CreateToken(string login, string email);
    }
}
