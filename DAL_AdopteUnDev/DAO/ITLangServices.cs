using AdopteUnDev_Common.IRepositories;
using DAL_AdopteUnDev.DTO;
using DAL_AdopteUnDev.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_AdopteUnDev.DAO
{
    public class ITLangServices : UseBaseConnection, IDeveloperRepository<ITLang>
    {
        //In DB ho già: C#; ASP MVC; JAVA; UML;
        //ma questo non vuol dire che io potrei sempre volet Modificare, Aggiungere .. dei linguaggi
        public void Delete(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [ITLang] WHERE [idIT] = @id";
                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);

                    c.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ITLang Get(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idIT],[ITLabel] FROM [ITLang] WHERE [idIT] = @id";
                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) return Mapper.ToITLang(reader);
                    return null;
                }
            }
        }

        public IEnumerable<ITLang> Get()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idIT],[ITLabel] FROM [ITLang]";

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToITLang(reader);
                }
            }
        }

        public int Insert(ITLang entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [ITLang]([ITLabel]) OUTPUT [inserted].[idIT] VALUES (@linguaggio)";
                    SqlParameter p_linguaggio = new SqlParameter("linguaggio", entity.ITLabel);

                    cmd.Parameters.Add(p_linguaggio);

                    c.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(int id, ITLang entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [ITLang] SET [ITLabel]=@linguaggio WHERE [idIT]=@id";

                    SqlParameter p_id = new SqlParameter("id", id);

                    SqlParameter p_linguaggio = new SqlParameter("linguaggio", entity.ITLabel);

                    cmd.Parameters.Add(p_id);
                    cmd.Parameters.Add(p_linguaggio);

                    c.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
