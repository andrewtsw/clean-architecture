using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;

namespace Dump2020.CleanArchitecture.UseCases.Invoices.Commands.CreateExternalInvoice
{
    public class CreateExternalInvoiceCommand : ICommand
    {
        public int InvoiceId { get; set; }
    }
}
