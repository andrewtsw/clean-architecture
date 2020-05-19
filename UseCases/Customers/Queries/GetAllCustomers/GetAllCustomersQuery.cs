using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using System.Collections.Generic;

namespace Dump2020.CleanArchitecture.UseCases.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IQuery<List<CustomerListDto>>
    {
    }
}
