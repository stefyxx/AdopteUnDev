using AdopteUnDev_Common.IRepositories;
using DAL_AdopteUnDev.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_AdopteUnDev.DAO
{
    public class ClientEndorseDevServices : UseBaseConnection, IRepositoryClientEndorseDev<ClientEndorseDev>
    {
        //NB: la PK é un token, una string e non un int
        public void Delete(string token)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Client] WHERE [idClient] = @id";
                    SqlParameter p_id = new SqlParameter("id", token);
                    cmd.Parameters.Add(p_id);

                    c.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClientEndorseDev Get(string token)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientEndorseDev> Get()
        {
            throw new NotImplementedException();
        }

        public string Insert(ClientEndorseDev entity)
        {
            throw new NotImplementedException();
        }

        public void Update(string token, ClientEndorseDev entity)
        {
            throw new NotImplementedException();
        }
    }
}
