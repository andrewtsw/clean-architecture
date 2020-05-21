using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using Dump2020.CleanArchitecture.Interfaces.BackgroundJobService;
using Dump2020.CleanArchitecture.UseCases.Invoices.Commands.CreateExternalInvoice;
using Dump2020.CleanArchitecture.UseCases.Invoices.Commands.UpdateExternalInvocie;
using Hangfire;
using System.Threading;

namespace Dump2020.CleanArchitecture.BackgroundJobService
{
    internal class CommandBackgroundJob : IBackgroundJobService
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public CommandBackgroundJob(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public void EnqueueCreateInvoice(int invoiceId)
        {
            BackgroundJob.Enqueue(() => _commandDispatcher.HandleAsync(
                new CreateExternalInvoiceCommand { InvoiceId = invoiceId },
                CancellationToken.None));
        }

        public void EnqueueUpdateInvoice(int invoiceId)
        {
            BackgroundJob.Enqueue(() => _commandDispatcher.HandleAsync(
                new UpdateExternalInvoiceCommand { InvoiceId = invoiceId },
                CancellationToken.None));
        }
    }
}
