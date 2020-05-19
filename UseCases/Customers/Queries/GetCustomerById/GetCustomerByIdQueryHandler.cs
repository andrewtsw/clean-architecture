using AutoMapper;
using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using Dump2020.CleanArchitecture.Interfaces.DataAccess;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.UseCases.Customers.Queries.GetCustomerById
{
    internal class GetCustomerByIdQueryHandler : IQueryHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(IDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            var customer = await _dbContext
                .Customers
                .Where(c => c.Id == query.CustomerId)
                .SingleOrDefaultAsync(cancellationToken);

            //if (entity == null)
            //{
            //    throw new NotFoundException(nameof(Customer), request.Id);
            //}

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
