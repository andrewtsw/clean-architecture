using MediatR;

namespace Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
