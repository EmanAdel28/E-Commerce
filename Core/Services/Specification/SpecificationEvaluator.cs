using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Models;

namespace Abstraction
{
    public class SpecificationEvaluator
    {
        public IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> InputQuery, ISpecifications<TEntity, TKey> spec) where TEntity : ModelBase<TKey>
        {
            var Query = InputQuery;
            if (spec.Criteria is not null)
                Query = Query.Where(spec.Criteria);

            if (spec.IncludeExpressions is not null && spec.IncludeExpressions.Count > 0)
                Query = spec.IncludeExpressions.Aggregate(Query, (CurrentQuery, Exp) => CurrentQuery.Include(Exp));

            return Query;

        }
    }
    }

