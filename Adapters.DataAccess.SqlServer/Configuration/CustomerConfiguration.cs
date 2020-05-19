using Dump2020.CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dump2020.CleanArchitecture.Adapters.DataAccess.SqlServer.Configuration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasMany(i => i.Invoices)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
