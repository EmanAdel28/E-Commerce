using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Models;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class UnitOfWork(StoreDbContext context) : IUnitOfWork
    {
        private readonly  Dictionary<string,object> _Repositories = new Dictionary<string, object>();
        public IGenericReposetory<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : ModelBase<TKey>
        {
            var TypaName = typeof(TEntity).Name;
            if (_Repositories.ContainsKey(TypaName))
                return (IGenericReposetory<TEntity, TKey>)_Repositories[TypaName];

            var Repo = new GenericRepository<TEntity, TKey>(context);

            _Repositories.Add(TypaName, Repo);
            return Repo;

        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
