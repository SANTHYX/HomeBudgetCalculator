using HomeBudgetCalculator.Infrastructure.Commands.Interfaces;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.Infrastructure.Handlers.Interfaces
{
    public interface ICommandDispatcher : ICommand
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}
