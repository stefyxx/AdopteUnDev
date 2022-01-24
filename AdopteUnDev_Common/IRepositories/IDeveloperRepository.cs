using System;
using System.Collections.Generic;
using System.Text;

namespace AdopteUnDev_Common.IRepositories
{
    public interface IDeveloperRepository<TEntity>: IRepository<TEntity>,IGetRepository<TEntity>
    {
    }
}
