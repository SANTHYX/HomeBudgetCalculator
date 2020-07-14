﻿using HomeBudgetCalculator.Infrastructure.Commands.Interface;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Handlers.Interfaces
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
