using Dump2020.CleanArchitecture.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Dump2020.CleanArchitecture.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
