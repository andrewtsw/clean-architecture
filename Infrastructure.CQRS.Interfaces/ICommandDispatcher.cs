using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces
{
    public interface ICommandDispatcher
    {
        Task<TResponse> HandleAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken);

        Task HandleAsync(ICommand command, CancellationToken cancellationToken);
    }
}
