using System;
using System.Collections.Generic;
using System.Text;

namespace AdopteUnDev_Common.IRepositories
{
    public interface IRepository<TEntity>
    {
        int Insert(TEntity entity);
        void Delete(int id);
        void Update(int id, TEntity entity);

    }
}
