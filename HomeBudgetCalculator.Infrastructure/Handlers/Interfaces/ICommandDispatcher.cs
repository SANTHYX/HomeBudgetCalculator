﻿using HomeBudgetCalculator.Infrastructure.Commands.Interface;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Handlers.Interfaces
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}
