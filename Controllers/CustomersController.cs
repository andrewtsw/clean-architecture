using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using Dump2020.CleanArchitecture.UseCases.Customers.Commands.UpdateCustomer;
using Dump2020.CleanArchitecture.UseCases.Customers.Queries.GetAllCustomers;
using Dump2020.CleanArchitecture.UseCases.Customers.Queries.GetCustomerById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public CustomersController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        /// <summary>
        /// Get all customers.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>All customers.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<CustomerListDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _queryDispatcher.AskAsync(new GetAllCustomersQuery(), cancellationToken);
        }

        /// <summary>
        /// Get customer by id.
        /// </summary>
        /// <param name="id">Customer id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Customer.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<CustomerDto> GetById(int id, CancellationToken cancellationToken)
        {
            return await _queryDispatcher.AskAsync(new GetCustomerByIdQuery { CustomerId = id }, cancellationToken);
        }

        /// <summary>
        /// Update a customer.
        /// </summary>
        /// <param name="id">Customer Id.</param>
        /// <param name="dto">Update customer model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task Update(int id, [Required] UpdateCustomerDto dto, CancellationToken cancellationToken)
        {
            await _commandDispatcher.HandleAsync(new UpdateCustomerCommand(id, dto), cancellationToken);
        }
    }
}
