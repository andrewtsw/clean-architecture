using Dump2020.CleanArchitecture.Interfaces.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dump2020.CleanArchitecture.Adapters.DataAccess.SqlServer
{
    internal class EfCoreIncludableQueryable<TEntity, TProperty> : IIncludableQueryable<TEntity, TProperty>,
        Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<TEntity, TProperty>
    {
        private readonly IQueryable<TEntity> _source;

        public EfCoreIncludableQueryable(IQueryable<TEntity> source)
        {
            _source = source;
        }

        public Type ElementType => _source.ElementType;

        public Expression Expression => _source.Expression;

        public IQueryProvider Provider => _source.Provider;

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _source.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _source.GetEnumerator();
        }
    }
}
