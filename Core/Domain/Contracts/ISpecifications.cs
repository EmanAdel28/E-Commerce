﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Contracts
{
    public interface ISpecifications<TEntity, TKey> where TEntity : ModelBase<TKey>
    {
        Expression<Func<TEntity,bool>>? Criteria { get; }
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get;  }
        Expression<Func<TEntity, object>>? OrderBy { get; }
        Expression<Func<TEntity, object>>? OrderByDesc { get; }

    }
}
