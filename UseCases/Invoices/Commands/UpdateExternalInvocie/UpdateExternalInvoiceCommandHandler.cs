using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using Dump2020.CleanArchitecture.Interfaces.DataAccess;
using Dump2020.CleanArchitecture.Interfaces.ExternalInvoicesService;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.UseCases.Invoices.Commands.UpdateExternalInvocie
{
    internal class UpdateExternalInvoiceCommandHandler : ICommandHandler<UpdateExternalInvoiceCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IExternalInvoicesService _externalInvoicesService;

        public UpdateExternalInvoiceCommandHandler(IDbContext dbContext, IExternalInvoicesService externalInvoicesService)
        {
            _dbContext = dbContext;
            _externalInvoicesService = externalInvoicesService;
        }

        public async Task<Unit> Handle(UpdateExternalInvoiceCommand command, CancellationToken cancellationToken)
        {
            var invoice = await _dbContext.Invoices.FindAsync(command.InvoiceId, cancellationToken);
            await _externalInvoicesService.UpdateAsync(invoice);

            return Unit.Value;
        }
    }
}
