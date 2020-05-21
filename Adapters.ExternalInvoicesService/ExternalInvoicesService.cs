using Dump2020.CleanArchitecture.Domain.Entities;
using Dump2020.CleanArchitecture.Interfaces.ExternalInvoicesService;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Adapters.ExternalInvoicesService
{
    internal class ExternalInvoicesService : IExternalInvoicesService
    {
        private const string FileName = "ExternalInvoices.txt";

        public async Task<string> CreateAsync(Invoice invoice)
        {
            using (var stream = File.OpenWrite(FileName))
            {
                var bytes = Encoding.ASCII.GetBytes($"Invoice {invoice.Id} created.");
                await stream.WriteAsync(bytes, 0, bytes.Length);
            }
            return $"ExternalId = {invoice.Id}";                
        }

        public async Task UpdateAsync(Invoice invoice)
        {
            // TODO: add file lock. Append file, do not override it.
            using (var stream = File.OpenWrite(FileName))
            {
                var bytes = Encoding.ASCII.GetBytes($"Invoice {invoice.Id} updated.");
                await stream.WriteAsync(bytes, 0, bytes.Length);
            }
        }
    }
}
