using Dump2020.CleanArchitecture.Domain.Entities;
using Dump2020.CleanArchitecture.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Adapters.DataAccess.SqlServer
{
    internal class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceLineItem> InvoiceLineItem { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        IDbSet<Invoice> IDbContext.Invoices => new AppDbSet<Invoice>(Invoices);

        IDbSet<Product> IDbContext.Products => new AppDbSet<Product>(Products);

        Task<int> IDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return SaveChangesAsync(cancellationToken);
        }
    }
}
