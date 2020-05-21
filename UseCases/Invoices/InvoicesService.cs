using Dump2020.CleanArchitecture.Interfaces.DataAccess;
using Dump2020.CleanArchitecture.Interfaces.ExternalInvoicesService;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.UseCases.Invoices
{
    internal class InvoicesService : IInvoicesService
    {
        private readonly IDbContext _dbContext;
        private readonly IExternalInvoicesService _externalInvoicesService;

        public InvoicesService(IDbContext dbContext, IExternalInvoicesService externalInvoicesService)
        {
            _dbContext = dbContext;
            _externalInvoicesService = externalInvoicesService;
        }

        public async Task CreateExternalAsync(int invoiceId, CancellationToken cancellationToken)
        {
            var invoice = await _dbContext.Invoices.FindAsync(invoiceId, cancellationToken);
            var externalId = await _externalInvoicesService.CreateAsync(invoice);
            invoice.ExternalId = externalId;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateExternalAsync(int invoiceId, CancellationToken cancellationToken)
        {
            var invoice = await _dbContext.Invoices.FindAsync(invoiceId, cancellationToken);
            await _externalInvoicesService.UpdateAsync(invoice);
        }
    }
}
