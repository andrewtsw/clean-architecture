using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Infrastructure.CQRS.Mediator
{
    internal class QueryDispatcher : IQueryDispatcher
    {
        private readonly IMediator _mediator;

        public QueryDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResponse> AskAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken)
        {
            return _mediator.Send(query, cancellationToken);
        }
    }
}
