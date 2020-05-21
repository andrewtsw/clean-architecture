using AutoMapper;
using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using Dump2020.CleanArchitecture.Infrastructure.Events.Interfaces;
using Dump2020.CleanArchitecture.Interfaces.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.UseCases.Customers.Commands.UpdateCustomer
{
    internal class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IEventDispatcher _eventDispatcher;

        public UpdateCustomerCommandHandler(IDbContext dbContext, IMapper mapper, IEventDispatcher eventDispatcher)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _eventDispatcher = eventDispatcher;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Customers.FindAsync(command.CustomerId, cancellationToken);
            //if (entity == null)
            //{
            //    throw new NotFoundException(nameof(Customer), request.Id);
            //}
            _mapper.Map(command.UpdateCustomerDto, customer);
            await _dbContext.SaveChangesAsync(cancellationToken);

            await _eventDispatcher.Send(new CustomerUpdatedEvent(customer.Id), cancellationToken);

            return Unit.Value;
        }
    }
}
