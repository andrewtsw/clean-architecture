using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Infrastructure.CQRS.Mediator
{
    internal class CommandDispatcher : ICommandDispatcher
    {
        private readonly IMediator _mediator;

        public CommandDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResponse> HandleAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken)
        {
            return _mediator.Send(command, cancellationToken);
        }

        public Task HandleAsync(ICommand command, CancellationToken cancellationToken)
        {
            return _mediator.Send(command, cancellationToken);
        }
    }
}
