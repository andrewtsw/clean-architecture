using Dump2020.CleanArchitecture.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Dump2020.CleanArchitecture.Adapters.DataAccess.SqlServer
{
    internal class EfCoreQueryableAdapter : IQueryableAdapter
    {
        public IIncludableQueryable<TEntity, TProperty> Include<TEntity, TProperty>(IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>> navigationPropertyPath) where TEntity : class
        {
            var efCoreIncludable = EntityFrameworkQueryableExtensions.Include(source, navigationPropertyPath);
            return new EfCoreIncludableQueryable<TEntity, TProperty>(efCoreIncludable);
        }

        public Task<TEntity> SingleOrDefaultAsync<TEntity>(IQueryable<TEntity> source, CancellationToken cancellationToken)
        {
            return EntityFrameworkQueryableExtensions.SingleOrDefaultAsync(source, cancellationToken);
        }

        public Task<List<TEntity>> ToListAsync<TEntity>(IQueryable<TEntity> source, CancellationToken cancellationToken)
        {
            return EntityFrameworkQueryableExtensions.ToListAsync(source, cancellationToken);
        }

        public IIncludableQueryable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
            IIncludableQueryable<TEntity, TPreviousProperty> source, 
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath) 
            where TEntity : class
        {
            var efCoreIncludableSource = new EfCoreIncludableQueryable<TEntity, TPreviousProperty>(source);
            var efCoreIncludableResult = EntityFrameworkQueryableExtensions.ThenInclude(efCoreIncludableSource, navigationPropertyPath);
            return new EfCoreIncludableQueryable<TEntity, TProperty>(efCoreIncludableResult);
        }

        public IIncludableQueryable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
            IIncludableQueryable<TEntity, IEnumerable<TPreviousProperty>> source, 
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath) 
            where TEntity : class
        {
            var efCoreIncludableSource = new EfCoreIncludableQueryable<TEntity, IEnumerable<TPreviousProperty>>(source);
            var efCoreIncludableResult = EntityFrameworkQueryableExtensions.ThenInclude(efCoreIncludableSource, navigationPropertyPath);
            return new EfCoreIncludableQueryable<TEntity, TProperty>(efCoreIncludableResult);
        }
    }
}
