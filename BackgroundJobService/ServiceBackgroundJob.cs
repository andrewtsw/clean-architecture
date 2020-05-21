using Dump2020.CleanArchitecture.Interfaces.BackgroundJobService;
using Dump2020.CleanArchitecture.UseCases.Invoices;
using Hangfire;
using System.Threading;

namespace Dump2020.CleanArchitecture.BackgroundJobService
{
    internal class ServiceBackgroundJob : IBackgroundJobService
    {
        private readonly IInvoicesService _invoicesService;

        public ServiceBackgroundJob(IInvoicesService invoicesService)
        {
            _invoicesService = invoicesService;
        }

        public void EnqueueCreateInvoice(int invoiceId)
        {
            BackgroundJob.Enqueue(() => _invoicesService.CreateExternalAsync(invoiceId, CancellationToken.None));
        }

        public void EnqueueUpdateInvoice(int invoiceId)
        {
            BackgroundJob.Enqueue(() => _invoicesService.UpdateExternalAsync(invoiceId, CancellationToken.None));
        }
    }
}
