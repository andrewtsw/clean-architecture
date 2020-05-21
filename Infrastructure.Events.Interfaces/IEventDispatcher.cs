using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Infrastructure.Events.Interfaces
{
    public interface IEventDispatcher
    {
        Task Send<TEvent>(TEvent @event, CancellationToken cancellationToken)
            where TEvent : IEvent;
    }
}
