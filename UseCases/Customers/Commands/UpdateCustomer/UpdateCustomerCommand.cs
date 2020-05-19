using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;

namespace Dump2020.CleanArchitecture.UseCases.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : ICommand
    {
        public UpdateCustomerCommand(int id, UpdateCustomerDto dto)
        {
            CustomerId = id;
            UpdateCustomerDto = dto;
        }

        public int CustomerId { get; set; }

        public UpdateCustomerDto UpdateCustomerDto { get; }
    }
}
