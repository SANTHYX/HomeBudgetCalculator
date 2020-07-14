using AutoMapper;
using HomeBudgetCalculator.Core.Domains;
using HomeBudgetCalculator.Infrastructure.DTO;

namespace HomeBudgetCalculator.Infrastructure.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<User, UserDTO>();
        }
    }
}
