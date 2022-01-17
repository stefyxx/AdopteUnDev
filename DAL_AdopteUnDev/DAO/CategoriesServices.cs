using AdopteUnDev_Common.IRepositories;
using DAL_AdopteUnDev.DTO;
using DAL_AdopteUnDev.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_AdopteUnDev.DAO
{
    public class CategoriesServices : UseBaseConnection, IRepository<Categories>, IGetRepository<Categories>
    {
        //In DB ho già: WEB; ANALYSE; WEBAPP; GEEK; WPF; Incrédules
        //ma questo non vuol dire che io potrei sempre volet Modificare, Aggiungere .. delle categorie
        public void Delete(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Categories] WHERE [idCategory] = @id";
                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);

                    c.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Categories Get(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idCategory],[CategLabel] FROM [Categories] WHERE [idCategory] = @id";
                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) return Mapper.ToCategories(reader);
                    return null;
                }
            }
        }

        public IEnumerable<Categories> Get()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idCategory],[CategLabel] FROM [Categories]";

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToCategories(reader);
                }
            }
        }

        public int Insert(Categories entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Categories]([CategLabel]) OUTPUT [inserted].[idCategory] VALUES (@categoria)";
                    SqlParameter p_categoria = new SqlParameter("categoria", entity.CategLabel);

                    cmd.Parameters.Add(p_categoria);

                    c.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(int id, Categories entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Categories] SET [CategLabel]=@categoria WHERE [idCategory]=@id";

                    SqlParameter p_id = new SqlParameter("id", id);

                    SqlParameter p_categoria = new SqlParameter("categoria", entity.CategLabel);

                    cmd.Parameters.Add(p_id);
                    cmd.Parameters.Add(p_categoria);

                    c.Open();

                   cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
