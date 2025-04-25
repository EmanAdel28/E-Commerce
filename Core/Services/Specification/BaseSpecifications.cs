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
        public Expression<Func<TEntity, object>>? OrderBy {  get;private set; }

        public Expression<Func<TEntity, object>>? OrderByDesc { get; private set; }

        protected void AddOrderBy(Expression<Func<TEntity, object>>? OrderByExpression)
        {
            OrderBy = OrderByExpression;
        }

        protected void AddOrderByDesc(Expression<Func<TEntity, object>>? OrderByDescExpression)
        {
            OrderByDesc = OrderByDescExpression;
        }
        #endregion

        #region Pagination

        public int Skip { get; private set; }

        public int Take { get; private set; }

        public bool IsPaginated { get ; set ; }

        protected void ApplyPagination(int pageSize , int PageIngex)
        {
            IsPaginated = true;
            Take = pageSize;
            Skip = (PageIngex-1)*pageSize;
        }

        #endregion


    }
}
