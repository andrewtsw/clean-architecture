using Dump2020.CleanArchitecture.Domain.Entities;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Interfaces.ExternalInvoicesService
{
    public interface IExternalInvoicesService
    {
        Task<string> CreateAsync(Invoice invoice);
    }
}
