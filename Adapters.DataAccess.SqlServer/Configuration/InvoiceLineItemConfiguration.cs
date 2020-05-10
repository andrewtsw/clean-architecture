using Dump2020.CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dump2020.CleanArchitecture.Adapters.DataAccess.SqlServer.Configuration
{
    internal class InvoiceLineItemConfiguration : IEntityTypeConfiguration<InvoiceLineItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceLineItem> builder)
        {
            builder.HasOne(ln => ln.Product)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}