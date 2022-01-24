using System;
using System.Collections.Generic;
using System.Text;

namespace AdopteUnDev_Common.IRepositories
{
    public interface IRepositoryTab_Intermediarie<TEntity, Tint, T2int>
    {
        TEntity Get(Tint id1, T2int id2);
        IEnumerable<TEntity> Get();

    }
}
