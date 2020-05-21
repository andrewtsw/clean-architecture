using MediatR;

namespace Dump2020.CleanArchitecture.Infrastructure.Events.Interfaces
{
    public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
        where TEvent : IEvent
    {
    }
}
