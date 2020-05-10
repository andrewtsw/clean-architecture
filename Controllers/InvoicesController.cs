using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using Dump2020.CleanArchitecture.UseCases.Invoices.Commands.CreateInvoice;
using Dump2020.CleanArchitecture.UseCases.Invoices.Commands.DeleteInvoice;
using Dump2020.CleanArchitecture.UseCases.Invoices.Queries.GetAllInvoices;
using Dump2020.CleanArchitecture.UseCases.Invoices.Queries.GetInvoiceById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Controllers
{
    [ApiController]
    [Route("invoices")]
    public class InvoicesController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public InvoicesController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        /// <summary>
        /// Get all invoices.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>All invoices.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<InvoiceListDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _queryDispatcher.AskAsync(new GetAllInvoicesQuery(), cancellationToken);
        }

        /// <summary>
        /// Get invoice by id.
        /// </summary>
        /// <param name="id">Invoice id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Invoice.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<InvoiceDto> GetById(int id, CancellationToken cancellationToken)
        {
            return await _queryDispatcher.AskAsync(new GetInvoiceByIdQuery { InvoiceId = id }, cancellationToken);
        }

        /// <summary>
        /// Create a new invoice.
        /// </summary>
        /// <param name="dto">Create invoice model.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Id of created invoce.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<int> Create([Required] CreateInvoiceDto dto, CancellationToken cancellationToken)
        {
            return await _commandDispatcher.HandleAsync(new CreateInvoiceCommand(dto), cancellationToken);
        }

        /// <summary>
        /// Delete an invoice.
        /// </summary>
        /// <param name="id">Invoice id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _commandDispatcher.HandleAsync(new DeleteInvoiceCommand { Id = id }, cancellationToken);
        }
    }
}
