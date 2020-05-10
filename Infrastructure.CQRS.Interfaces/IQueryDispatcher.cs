using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces
{
    public interface IQueryDispatcher
    {
        Task<TResponse> AskAsync<TResponse>(IQuery<TResponse> request, CancellationToken cancellationToken);
    }
}
