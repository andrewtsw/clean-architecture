using Dump2020.CleanArchitecture.Domain.Base;
using Dump2020.CleanArchitecture.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Dump2020.CleanArchitecture.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public InvoiceType Type { get; set; }

        [MaxLength(50)]
        public string ExternalId { get; set; }

        public ICollection<InvoiceLineItem> LineItems { get; private set; } = new HashSet<InvoiceLineItem>();

        public decimal CalculateTotal()
        {
            return LineItems.Sum(lineItem => lineItem.CalculateTotal());
        }
    }
}
