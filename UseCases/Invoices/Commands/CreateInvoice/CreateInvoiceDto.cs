﻿using Dump2020.CleanArchitecture.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Dump2020.CleanArchitecture.UseCases.Invoices.Commands.CreateInvoice
{
    public class CreateInvoiceDto : IValidatableObject
    {
        /// <summary>
        /// Type.
        /// </summary>
        public InvoiceType Type { get; set; }

        /// <summary>
        /// Line items.
        /// </summary>
        public List<CreateInvoiceLineItemDto> LineItems { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (LineItems == null || !LineItems.Any())
            {
                yield return new ValidationResult(
                    $"LineItems con no be empty",
                    new[] { nameof(LineItems) });
            }
        }
    }

    public class CreateInvoiceLineItemDto : IValidatableObject
    {
        public int ProductId { get; set; }

        public int Count { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ProductId <= 0)
            {
                yield return new ValidationResult($"ProductId must be positive.", new[] { nameof(ProductId) });
            }

            if (Count <= 0)
            {
                yield return new ValidationResult($"Count must be positive.", new[] { nameof(Count) });
            }
        }
    }
}
