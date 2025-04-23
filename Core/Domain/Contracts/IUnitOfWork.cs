using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IGenericReposetory<TEntity, TKey> GetRepository<TEntity, TKey>() where   TEntity : ModelBase<TKey>;
    }
}
