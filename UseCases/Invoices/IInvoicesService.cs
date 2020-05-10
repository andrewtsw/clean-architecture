using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.UseCases.Invoices
{
    public interface IInvoicesService
    {
        Task CreateExternalAsync(int invoiceId, CancellationToken cancellationToken);
    }
}
