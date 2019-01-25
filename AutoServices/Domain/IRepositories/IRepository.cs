using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Items { get; }
        Task Save(TEntity item);
        void Delete(Guid itemId);
    }
}
