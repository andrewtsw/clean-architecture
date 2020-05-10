using MediatR;

namespace Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}