using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using System.Collections.Generic;

namespace Dump2020.CleanArchitecture.UseCases.Invoices.Queries.GetAllInvoices
{
    public class GetAllInvoicesQuery : IQuery<List<InvoiceListDto>>
    {
    }
}
