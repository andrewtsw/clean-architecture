using AutoMapper;
using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using Dump2020.CleanArchitecture.Interfaces.DataAccess;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.UseCases.Invoices.Queries.GetInvoiceById
{
    internal class GetInvoiceByIdQueryHandler : IQueryHandler<GetInvoiceByIdQuery, InvoiceDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetInvoiceByIdQueryHandler(IDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<InvoiceDto> Handle(GetInvoiceByIdQuery query, CancellationToken cancellationToken)
        {
            var invoice = await _dbContext
                .Invoices
                .Where(i => i.Id == query.InvoiceId)
                .Include(i => i.LineItems)
                    .ThenInclude(li => li.Product)
                .SingleOrDefaultAsync(cancellationToken);

            //if (entity == null)
            //{
            //    throw new NotFoundException(nameof(Invoice), request.Id);
            //}

            return _mapper.Map<InvoiceDto>(invoice);
        }
    }
}
