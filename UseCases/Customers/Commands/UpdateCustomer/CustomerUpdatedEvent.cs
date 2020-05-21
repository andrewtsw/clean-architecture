using Dump2020.CleanArchitecture.Infrastructure.Events.Interfaces;

namespace Dump2020.CleanArchitecture.UseCases.Customers.Commands.UpdateCustomer
{
    public class CustomerUpdatedEvent : IEvent
    {
        public CustomerUpdatedEvent(int custmerId)
        {
            CustomerId = custmerId;
        }

        public int CustomerId { get; }
    }
}
