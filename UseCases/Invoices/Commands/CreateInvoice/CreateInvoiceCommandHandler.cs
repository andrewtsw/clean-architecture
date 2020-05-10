using AutoMapper;
using Dump2020.CleanArchitecture.Domain.Entities;
using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using Dump2020.CleanArchitecture.Interfaces.BackgroundJobService;
using Dump2020.CleanArchitecture.Interfaces.DataAccess;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.UseCases.Invoices.Commands.CreateInvoice
{
    internal class CreateInvoiceCommandHandler : ICommandHandler<CreateInvoiceCommand, int>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IBackgroundJobService _backgroundJobService;

        public CreateInvoiceCommandHandler(IDbContext context, IMapper mapper, IBackgroundJobService backgroundJobService)
        {
            _dbContext = context;
            _mapper = mapper;
            _backgroundJobService = backgroundJobService;
        }

        public async Task<int> Handle(CreateInvoiceCommand command, CancellationToken cancellationToken)
        {
            var invoice = _mapper.Map<Invoice>(command.CreateInvoiceDto);

            _dbContext.Invoices.Add(invoice);
            await _dbContext.SaveChangesAsync(cancellationToken);

            _backgroundJobService.EnqueueCreateInvoice(invoice.Id);

            return invoice.Id;
        }
    }
}
