using System;
using System.Collections.Generic;
using System.Text;

namespace AdopteUnDev_Common.IRepositories
{
    public interface IRepositoryClientEndorseDev<TEntity>
    {
        TEntity Get(string token);
        IEnumerable<TEntity> Get();
        string Insert(TEntity entity);
        void Delete(string token);
        void Update(string token, TEntity entity);
    }
}
