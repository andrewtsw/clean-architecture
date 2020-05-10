using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;

namespace Dump2020.CleanArchitecture.UseCases.Invoices.Queries.GetInvoiceById
{
    public class GetInvoiceByIdQuery : IQuery<InvoiceDto>
    {
        public int InvoiceId { get; set; }
    }
}
