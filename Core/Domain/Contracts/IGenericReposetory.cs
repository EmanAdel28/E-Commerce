using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Contracts
{
    public interface IGenericReposetory<TEntity , TKey> where TEntity : ModelBase<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey id);
        void Add(TEntity entity);   
        void Update(TEntity entity);   
        void Delete(TEntity entity);

    }
}
