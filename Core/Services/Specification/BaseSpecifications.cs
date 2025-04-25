using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Models;

namespace Services.Specification
{
    public class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : ModelBase<TKey>
    {

        #region Criteria
        public BaseSpecifications(Expression<Func<TEntity, bool>>? PassedExpression)
        {
            Criteria = PassedExpression;
        }
        public Expression<Func<TEntity, bool>>? Criteria { get; private set; }
        #endregion

        #region Include
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new List<Expression<Func<TEntity, object>>>();
        protected void AddInclude(Expression<Func<TEntity, object>> IncludeExp)
        {
            IncludeExpressions.Add(IncludeExp);
        }

        #endregion

        #region OrderBy
        public Expression<Func<TEntity, bool>>? OrderBy {  get;private set; }

        public Expression<Func<TEntity, bool>>? OrderByDesc { get; private set; }

        protected void AddOrderBy(Expression<Func<TEntity, bool>>? OrderByExpression)
        {
            OrderBy = OrderByExpression;
        }

        protected void AddOrderByDesc(Expression<Func<TEntity, bool>>? OrderByDescExpression)
        {
            OrderByDesc = OrderByDescExpression;
        }
        #endregion


    }
}
