using Dump2020.CleanArchitecture.Domain.Base;

namespace Dump2020.CleanArchitecture.Domain.Entities
{
    public class InvoiceLineItem : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Count { get; set; }

        public decimal CalculateTotal()
        {
            return Product.Price * Count;
        }
    }
}
