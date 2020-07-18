using AutoMapper;
using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.DTO;
using System.Security.Cryptography.X509Certificates;

namespace HomeBudgetCalculator.Infrastructure.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Budget, BudgetDTO>().ReverseMap();
            CreateMap<Income, IncomeDTO>().ReverseMap();
            CreateMap<Expense, ExpenseDTO>().ReverseMap();
        }
    }
}
