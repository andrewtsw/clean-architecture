using Dump2020.CleanArchitecture.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dump2020.CleanArchitecture.UseCases.Invoices.Queries.GetInvoiceById
{
    /// <summary>
    /// Invoice.
    /// </summary>
    public class InvoiceDto
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        public InvoiceType Type { get; set; }

        /// <summary>
        /// External Id.
        /// </summary>
        [MaxLength(50)]
        public string ExternalId { get; set; }

        /// <summary>
        /// Line items.
        /// </summary>
        public List<InvoiceLineItemDto> LineItems { get; set; }

        /// <summary>
        /// Total.
        /// </summary>
        public decimal Total { get; set; }
    }
}
