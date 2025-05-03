using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class GenericRepository<TEntity, IKey>(StoreDbContext context) : IGenericReposetory<TEntity, IKey> where TEntity : ModelBase<IKey>
    {

        public async Task<IEnumerable<TEntity>> GetAllAsync()
         => await context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(IKey id)
        => await context.Set<TEntity>().FindAsync(id);
        public void Add(TEntity entity)
        =>  context.Set<TEntity>().Add(entity);


        public void Update(TEntity entity)
       => context.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity)
       => context.Set<TEntity>().Remove(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, IKey> spec)
        {
            return await SpecificationEvaluator.CreateQuery(context.Set<TEntity>(), spec).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(ISpecifications<TEntity, IKey> spec)
        {
            return await SpecificationEvaluator.CreateQuery(context.Set<TEntity>(), spec).FirstOrDefaultAsync();
        }

       public async Task<int> CountAsync(ISpecifications<TEntity, IKey> spec)
        {
           return await SpecificationEvaluator.CreateQuery(context.Set<TEntity>(),spec).CountAsync();
        }
    }

}
