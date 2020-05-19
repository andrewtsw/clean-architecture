using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using Dump2020.CleanArchitecture.Interfaces.DataAccess;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.UseCases.Customers.Queries.GetAllCustomers
{
    internal class GetAllCustomersQueryHandler : IQueryHandler<GetAllCustomersQuery, List<CustomerListDto>>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(IDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<List<CustomerListDto>> Handle(GetAllCustomersQuery query, CancellationToken cancellationToken)
        {
            var customers = await _dbContext
                .Customers
                .ProjectTo<CustomerListDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return customers;
        }
    }
}
