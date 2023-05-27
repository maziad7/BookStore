using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
   public interface IBookStoreRepository<TEntity>
    {
        IList<TEntity> list();
        TEntity find(int id);
        void add(TEntity entity);
        void update(int id ,TEntity entity);
        void Delete(int id);
    }
}
