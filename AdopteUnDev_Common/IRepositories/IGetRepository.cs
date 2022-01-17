using System;
using System.Collections.Generic;
using System.Text;

namespace AdopteUnDev_Common.IRepositories
{
    public interface IGetRepository<TEntity>
    {
        TEntity Get(int id);
        IEnumerable<TEntity> Get();
    }
}
