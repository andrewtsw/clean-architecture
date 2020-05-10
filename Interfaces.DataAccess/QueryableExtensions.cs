using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Interfaces.DataAccess
{
    public static class QueryableExtensions
    {
        public static IQueryableAdapter QueryableAdapter { get; set; }

        public static Task<T> SingleOrDefaultAsync<T>(this IQueryable<T> source, CancellationToken cancellationToken)
        {
            return QueryableAdapter.SingleOrDefaultAsync(source, cancellationToken);
        }

        public static Task<List<TEntity>> ToListAsync<TEntity>(this IQueryable<TEntity> source, CancellationToken cancellationToken)
        {
            return QueryableAdapter.ToListAsync(source, cancellationToken);
        }

        public static IIncludableQueryable<TEntity, TProperty> Include<TEntity, TProperty>(
            this IQueryable<TEntity> source, 
            Expression<Func<TEntity, TProperty>> navigationPropertyPath)
            where TEntity : class
        {
            return QueryableAdapter.Include(source, navigationPropertyPath);
        }

        public static IIncludableQueryable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
            this IIncludableQueryable<TEntity, TPreviousProperty> source,
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TEntity : class
        {
            return QueryableAdapter.ThenInclude(source, navigationPropertyPath);
        }

        public static IIncludableQueryable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
            this IIncludableQueryable<TEntity, IEnumerable<TPreviousProperty>> source,
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TEntity : class
        {
            return QueryableAdapter.ThenInclude(source, navigationPropertyPath);
        }
    }
}
