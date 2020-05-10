using Dump2020.CleanArchitecture.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Interfaces.DataAccess
{
    public interface IDbContext
    {
        IDbSet<Invoice> Invoices { get; }

        IDbSet<Product> Products { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
