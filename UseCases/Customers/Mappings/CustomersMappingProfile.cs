using AutoMapper;
using Dump2020.CleanArchitecture.Domain.Entities;
using Dump2020.CleanArchitecture.UseCases.Customers.Commands.UpdateCustomer;
using Dump2020.CleanArchitecture.UseCases.Customers.Queries.GetAllCustomers;
using Dump2020.CleanArchitecture.UseCases.Customers.Queries.GetCustomerById;

namespace Dump2020.CleanArchitecture.UseCases.Customers.Mappings
{
    internal class CustomersMappingProfile : Profile
    {
        public CustomersMappingProfile()
        {
            // Queries.
            CreateMap<Customer, CustomerListDto>();

            CreateMap<Customer, CustomerDto>();

            // Commands.
            CreateMap<UpdateCustomerDto, Customer>();

        }
    }
}
