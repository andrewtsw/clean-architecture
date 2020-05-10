using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dump2020.CleanArchitecture.Interfaces.DataAccess
{
    public interface IIncludableQueryable<out TEntity, out TProperty> : IQueryable<TEntity>, IEnumerable<TEntity>, IEnumerable, IQueryable
    {
    }
}
