using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Interfaces.DataAccess
{
    public interface IDbSet<TEntity> : IQueryable<TEntity>, IEnumerable<TEntity>, IEnumerable, 
        IQueryable, IAsyncEnumerable<TEntity>
        where TEntity : class
    {
        TEntity Add(TEntity entity);

        ValueTask<TEntity> FindAsync<TKey>(TKey key, CancellationToken cancellationToken);

        TEntity Remove(TEntity invoice);
    }
}
