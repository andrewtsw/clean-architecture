using Dump2020.CleanArchitecture.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Adapters.DataAccess.SqlServer
{
    internal class AppDbSet<TEntity> : IDbSet<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        public AppDbSet(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        public Type ElementType => ((IQueryable<TEntity>)_dbSet).ElementType;

        public Expression Expression => ((IQueryable<TEntity>)_dbSet).Expression;

        public IQueryProvider Provider => ((IQueryable<TEntity>)_dbSet).Provider;

        public TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public ValueTask<TEntity> FindAsync<TKey>(TKey key, CancellationToken cancellationToken)
        {
            return _dbSet.FindAsync(key, cancellationToken);
        }

        public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return ((IAsyncEnumerable<TEntity>)_dbSet).GetAsyncEnumerator(cancellationToken);
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return ((IEnumerable<TEntity>)_dbSet).GetEnumerator();
        }

        public TEntity Remove(TEntity entity)
        {
            return _dbSet.Remove(entity).Entity;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_dbSet).GetEnumerator();
        }
    }
}
