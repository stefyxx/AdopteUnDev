using System;
using System.Collections.Generic;
using System.Text;

namespace AdopteUnDev_Common.IRepositories
{
    public interface ILangRepository<TEntity>
    {
        IEnumerable<int> Get(TEntity entity);
    }
}
