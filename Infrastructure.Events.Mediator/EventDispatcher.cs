using Dump2020.CleanArchitecture.Infrastructure.Events.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Infrastructure.Events.Mediator
{
    internal class EventDispatcher : IEventDispatcher
    {
        private readonly IMediator _mediator;

        public EventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Send<TEvent>(TEvent @event, CancellationToken cancellationToken)
            where TEvent : IEvent
        {
            return _mediator.Publish(@event, cancellationToken);
        }
    }
}
