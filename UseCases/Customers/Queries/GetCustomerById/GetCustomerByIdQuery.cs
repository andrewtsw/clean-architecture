using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;

namespace Dump2020.CleanArchitecture.UseCases.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IQuery<CustomerDto>
    {
        public int CustomerId { get; set; }
    }
}
