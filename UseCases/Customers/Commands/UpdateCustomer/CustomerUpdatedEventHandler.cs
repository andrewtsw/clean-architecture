using Dump2020.CleanArchitecture.Domain.Enums;
using Dump2020.CleanArchitecture.Infrastructure.Events.Interfaces;
using Dump2020.CleanArchitecture.Interfaces.BackgroundJobService;
using Dump2020.CleanArchitecture.Interfaces.DataAccess;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.UseCases.Customers.Commands.UpdateCustomer
{
    internal class CustomerUpdatedEventHandler : IEventHandler<CustomerUpdatedEvent>
    {
        private readonly IDbContext _dbContext;
        private readonly IBackgroundJobService _backgroundJobService;

        public CustomerUpdatedEventHandler(IDbContext dbContext, IBackgroundJobService backgroundJobService)
        {
            _dbContext = dbContext;
            _backgroundJobService = backgroundJobService;
        }

        public async Task Handle(CustomerUpdatedEvent @event, CancellationToken cancellationToken)
        {
            var invoices = await _dbContext.Invoices
                .Where(i => i.CustomerId == @event.CustomerId && i.Type == InvoiceType.Private)
                .ToListAsync(cancellationToken);

            foreach (var invoice in invoices)
            {
                _backgroundJobService.EnqueueUpdateInvoice(invoice.Id);
            }
        }
    }
}
