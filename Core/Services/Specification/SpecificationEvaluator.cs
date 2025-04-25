using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Domain.Contracts;
using Domain.Models;

namespace Abstraction
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(
            IQueryable<TEntity> InputQuery,
            ISpecifications<TEntity, TKey> spec) where TEntity : ModelBase<TKey>
        {
            var Query = InputQuery;

            if (spec.Criteria is not null)
                Query = Query.Where(spec.Criteria);

            if (spec.IncludeExpressions is not null && spec.IncludeExpressions.Count > 0)
            {
                Query = spec.IncludeExpressions.Aggregate(Query, (CurrentQuery, Exp) => CurrentQuery.Include(Exp));
            }

            return Query;
        }
    }
}
