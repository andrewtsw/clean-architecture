using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;

namespace Dump2020.CleanArchitecture.UseCases.Invoices.Commands.CreateInvoice
{
    public class CreateInvoiceCommand : ICommand<int>
    {
        public CreateInvoiceCommand(CreateInvoiceDto dto)
        {
            CreateInvoiceDto = dto;
        }

        public CreateInvoiceDto CreateInvoiceDto { get; }
    }
}
