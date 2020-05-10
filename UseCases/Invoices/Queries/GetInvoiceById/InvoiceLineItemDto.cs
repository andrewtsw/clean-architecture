using Dump2020.CleanArchitecture.UseCases.Common;

namespace Dump2020.CleanArchitecture.UseCases.Invoices.Queries.GetInvoiceById
{
    /// <summary>
    /// Invoice line item.
    /// </summary>
    public class InvoiceLineItemDto
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product.
        /// </summary>
        public LookupDto Product { get; set; }

        /// <summary>
        /// Count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Total.
        /// </summary>
        public decimal Total { get; set; }
    }
}
