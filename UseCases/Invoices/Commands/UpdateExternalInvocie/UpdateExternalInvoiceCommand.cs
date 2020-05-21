using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;

namespace Dump2020.CleanArchitecture.UseCases.Invoices.Commands.UpdateExternalInvocie
{
    public class UpdateExternalInvoiceCommand : ICommand
    {
        public int InvoiceId { get; set; }
    }
}
