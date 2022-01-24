using AdopteUnDev_Common.IRepositories;
using DAL_AdopteUnDev.DTO;
using DAL_AdopteUnDev.Handlers;
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
                    cmd.CommandText = "DELETE FROM [ClientEndorseDev] WHERE [EndorseNumber] = @id";
                    SqlParameter p_id = new SqlParameter("id", token);
                    cmd.Parameters.Add(p_id);

                    c.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClientEndorseDev Get(string token)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [EndorseNumber],[idClient],[idDev],[BeginDate],[EndDate] FROM [ClientEndorseDev] WHERE [EndorseNumber] = @id";
                    SqlParameter p_id = new SqlParameter("id", token);
                    cmd.Parameters.Add(p_id);

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) return Mapper.ToClientEndorseDev(reader);
                    return null;
                }
            }
        }

        public IEnumerable<ClientEndorseDev> Get()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [EndorseNumber],[idClient],[idDev],[BeginDate],[EndDate] FROM [ClientEndorseDev]";

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) yield return Mapper.ToClientEndorseDev(reader);
                }
            }
        }

        public string Insert(ClientEndorseDev entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [ClientEndorseDev]([idClient],[idDev],[BeginDate],[EndDate] OUTPUT [inserted].[EndorseNumber] VALUES (@idClient, @idDev, @startDate, @endDate)";
                    SqlParameter p_idClient = new SqlParameter("idClient", entity.idClient);
                    SqlParameter p_idDev = new SqlParameter("idDev", entity.idDev);
                    SqlParameter p_startDate = new SqlParameter("startDate", entity.BeginDate);
                    SqlParameter p_endDate = new SqlParameter("endDate", entity.EndDate);

                    cmd.Parameters.Add(p_idClient);
                    cmd.Parameters.Add(p_idDev);
                    cmd.Parameters.Add(p_startDate);
                    cmd.Parameters.Add(p_endDate);

                    c.Open();
                    return (string)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(string token, ClientEndorseDev entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [ClientEndorseDev] SET [idClient]=@idClient,[idDev]=@idDev,[BeginDate]=@startDate, [EndDate]=@endDate  WHERE [EndorseNumber]=@id";

                    SqlParameter p_id = new SqlParameter("id", token);

                    SqlParameter p_idClient = new SqlParameter("idClient", entity.idClient);
                    SqlParameter p_idDev = new SqlParameter("idDev", entity.idDev);
                    SqlParameter p_startDate = new SqlParameter("startDate", entity.BeginDate);
                    SqlParameter p_endDate = new SqlParameter("endDate", entity.EndDate);

                    cmd.Parameters.Add(p_id);
                    cmd.Parameters.Add(p_idClient);
                    cmd.Parameters.Add(p_idDev);
                    cmd.Parameters.Add(p_startDate);
                    cmd.Parameters.Add(p_endDate);

                    c.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
