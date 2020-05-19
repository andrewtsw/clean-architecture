using Dump2020.CleanArchitecture.Domain.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dump2020.CleanArchitecture.Domain.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        public ICollection<Invoice> Invoices { get; private set; } = new HashSet<Invoice>();
    }
}
