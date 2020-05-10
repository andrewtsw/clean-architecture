using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;

namespace Dump2020.CleanArchitecture.UseCases.Invoices.Commands.DeleteInvoice
{
    public class DeleteInvoiceCommand : ICommand
    {
        public int Id { get; set; }
    }
}
