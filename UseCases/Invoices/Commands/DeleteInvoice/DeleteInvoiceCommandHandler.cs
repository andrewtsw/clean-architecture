using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using Dump2020.CleanArchitecture.Interfaces.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.UseCases.Invoices.Commands.DeleteInvoice
{
    internal class DeleteInvoiceCommandHandler : ICommandHandler<DeleteInvoiceCommand>
    {
        private readonly IDbContext _dbContext;

        public DeleteInvoiceCommandHandler(IDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Unit> Handle(DeleteInvoiceCommand command, CancellationToken cancellationToken)
        {
            var invoice = await _dbContext.Invoices.FindAsync(command.Id, cancellationToken);
            //if (entity == null)
            //{
            //    throw new NotFoundException(nameof(Invoice), request.Id);
            //}
            _dbContext.Invoices.Remove(invoice);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
