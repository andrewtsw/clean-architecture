using Dump2020.CleanArchitecture.Domain.Entities;
using Dump2020.CleanArchitecture.Interfaces.ExternalInvoicesService;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Adapters.ExternalInvoicesService
{
    internal class ExternalInvoicesService : IExternalInvoicesService
    {
        public Task<string> CreateAsync(Invoice invoice)
        {
            // TODO: Use REST API or SDK for external service.
            return Task.FromResult($"ExternalId = {invoice.Id}");                
        }
    }
}
