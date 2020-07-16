using AutoMapper;
using HomeBudgetCalculator.Infrastructure.DTO;
using HomeBudgetCalculator.Infrastructure.Repositories.Interfaces;
using HomeBudgetCalculator.Infrastructure.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Service
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IMapper _mapper;

        public IncomeService(IIncomeRepository incomeRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }
        public Task AddIncomeAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteIncomeAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateIncomeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
