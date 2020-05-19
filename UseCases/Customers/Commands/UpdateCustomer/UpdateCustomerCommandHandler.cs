using AutoMapper;
using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
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

        public UpdateCustomerCommandHandler(IDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
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

            return Unit.Value;
        }
    }
}
