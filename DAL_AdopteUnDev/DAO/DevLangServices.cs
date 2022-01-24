using AdopteUnDev_Common.IRepositories;
using DAL_AdopteUnDev.DTO;
using DAL_AdopteUnDev.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL_AdopteUnDev.DAO
{
    public class DevLangServices : UseBaseConnection, IRepositoryTab_Intermediarie<DevLang, int, int>
    {
        public DevLang Get(int id1, int id2)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idDev],[idIT] [Since] FROM [DevLang] WHERE [idIT]= @idIT AND [idDev]= @idDev";

                    SqlParameter p_idIT = new SqlParameter("idIT", id1);
                    SqlParameter p_idDev = new SqlParameter("idDev", id2);

                    cmd.Parameters.Add(p_idIT);
                    cmd.Parameters.Add(p_idDev);

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) return Mapper.ToDevLang(reader);
                    return null;
                }
            }
        }

        public IEnumerable<DevLang> Get()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idDev],[idIT] [Since] FROM [DevLang]";

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToDevLang(reader);
                }
            }
        }

        public void Delete(int idIT, int idDev)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [DevLang] WHERE [idIT]= @idIT AND [idDev]= @idDev";
                    SqlParameter p_idIT = new SqlParameter("idIT", idIT);
                    SqlParameter p_idDev = new SqlParameter("idDev", idDev);

                    cmd.Parameters.Add(p_idIT);
                    cmd.Parameters.Add(p_idDev);

                    c.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Insert(DevLang entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [DevLang]([idDev],[idIT], [Since]) VALUES (@idIT, @idDev, @since)";
                    SqlParameter p_idIT = new SqlParameter("idIT", entity.idIT);
                    SqlParameter p_idDev = new SqlParameter("idDev", entity.idDev);
                    SqlParameter p_since = new SqlParameter("since", entity.Since);
                    c.Open();

                    cmd.ExecuteNonQuery();
                    //return (int)cmd.ExecuteScalar();
                }
            }
        }
        public void Update(int idIT, int idDev, DevLang entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [DevLang] SET [Since]=@since WHERE [idDev]=@idDev AND [idIT]=@idIT";
                    SqlParameter p_idIT = new SqlParameter("idIT", idIT);
                    SqlParameter p_idDev = new SqlParameter("idDev", idDev);
                    SqlParameter p_since = new SqlParameter("since", entity.Since);
                    c.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }

    }
}
