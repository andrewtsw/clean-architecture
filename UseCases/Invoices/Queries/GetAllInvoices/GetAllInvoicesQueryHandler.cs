using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using Dump2020.CleanArchitecture.Interfaces.DataAccess;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.UseCases.Invoices.Queries.GetAllInvoices
{
    internal class GetAllInvoicesQueryHandler : IQueryHandler<GetAllInvoicesQuery, List<InvoiceListDto>>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllInvoicesQueryHandler(IDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<List<InvoiceListDto>> Handle(GetAllInvoicesQuery query, CancellationToken cancellationToken)
        {
            var invoices = await _dbContext
                .Invoices
                .ProjectTo<InvoiceListDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return invoices;
        }
    }
}
