using AdopteUnDev_Common.IRepositories;
using DAL_AdopteUnDev.DTO;
using DAL_AdopteUnDev.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_AdopteUnDev.DAO
{
    public class LangCategServices : UseBaseConnection, IRepositoryTab_Intermediarie<LangCateg, int, int>
    {
        //ha 2 primary Keys:
        public LangCateg Get(int idIT, int idCategory)
        {
            using(SqlConnection c= new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idIT],[idCategory] FROM [LangCateg] WHERE [idIT]= @idIT AND [idCategory]= @idCategory";

                    SqlParameter p_idIT = new SqlParameter("idIT", idIT);
                    SqlParameter p_idCategory = new SqlParameter("idCategory", idCategory);

                    cmd.Parameters.Add(p_idIT);
                    cmd.Parameters.Add(p_idCategory);

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) return Mapper.ToLangCateg(reader);
                    return null;
                }
            }
        }

        public IEnumerable<LangCateg> Get()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idIT],[idCategory] FROM [LangCateg]";

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToLangCateg(reader);
                }
            }
        }
    }
}
