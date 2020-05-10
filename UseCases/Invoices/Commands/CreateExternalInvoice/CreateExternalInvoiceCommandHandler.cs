using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using Dump2020.CleanArchitecture.Interfaces.DataAccess;
using Dump2020.CleanArchitecture.Interfaces.ExternalInvoicesService;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.UseCases.Invoices.Commands.CreateExternalInvoice
{
    internal class CreateExternalInvoiceCommandHandler : ICommandHandler<CreateExternalInvoiceCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IExternalInvoicesService _externalInvoicesService;

        public CreateExternalInvoiceCommandHandler(IDbContext dbContext, IExternalInvoicesService externalInvoicesService)
        {
            _dbContext = dbContext;
            _externalInvoicesService = externalInvoicesService;
        }

        public async Task<Unit> Handle(CreateExternalInvoiceCommand command, CancellationToken cancellationToken)
        {
            var invoice = await _dbContext.Invoices.FindAsync(command.InvoiceId, cancellationToken);
            var externalId = await _externalInvoicesService.CreateAsync(invoice);
            invoice.ExternalId = externalId;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
