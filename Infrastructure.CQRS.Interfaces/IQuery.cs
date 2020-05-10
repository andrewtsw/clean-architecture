using MediatR;

namespace Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
