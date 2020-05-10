using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Interfaces.DataAccess
{
    public interface IQueryableAdapter
    {
        Task<TEntity> SingleOrDefaultAsync<TEntity>(IQueryable<TEntity> source, CancellationToken cancellationToken);

        Task<List<TEntity>> ToListAsync<TEntity>(IQueryable<TEntity> source, CancellationToken cancellationToken);

        IIncludableQueryable<TEntity, TProperty> Include<TEntity, TProperty>(
            IQueryable<TEntity> source, 
            Expression<Func<TEntity, TProperty>> navigationPropertyPath) 
            where TEntity : class;

        IIncludableQueryable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
            IIncludableQueryable<TEntity, TPreviousProperty> source,
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TEntity : class;


        IIncludableQueryable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
            IIncludableQueryable<TEntity, IEnumerable<TPreviousProperty>> source,
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TEntity : class;
    }
}
