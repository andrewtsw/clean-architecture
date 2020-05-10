using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using Dump2020.CleanArchitecture.Interfaces.BackgroundJobService;
using Dump2020.CleanArchitecture.UseCases.Invoices.Commands.CreateExternalInvoice;
using Hangfire;
using System.Threading;

namespace Dump2020.CleanArchitecture.BackgroundJobService
{
    internal class BackgroundJobService : IBackgroundJobService
    {
        //private readonly IInvoicesService _invoicesService;

        //public BackgroundJobService(IInvoicesService invoicesService)
        //{
        //    _invoicesService = invoicesService;
        //}

        //public void EnqueueCreateInvoice(int invoiceId)
        //{
        //    BackgroundJob.Enqueue(() => _invoicesService.CreateExternalAsync(invoiceId));
        //}

        private readonly ICommandDispatcher _commandDispatcher;

        public BackgroundJobService(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public void EnqueueCreateInvoice(int invoiceId)
        {
            BackgroundJob.Enqueue(() => _commandDispatcher.HandleAsync(
                new CreateExternalInvoiceCommand { InvoiceId = invoiceId },
                CancellationToken.None));
        }
    }
}
