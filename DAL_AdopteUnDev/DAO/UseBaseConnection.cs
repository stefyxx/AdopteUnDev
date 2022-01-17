using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_AdopteUnDev.DAO
{
    public abstract class UseBaseConnection
    {
        protected string _connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AdopteUnDev;Integrated Security=True";
    }
}
