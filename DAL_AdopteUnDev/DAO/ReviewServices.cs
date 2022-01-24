using AdopteUnDev_Common.IRepositories;
using DAL_AdopteUnDev.DTO;
using DAL_AdopteUnDev.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_AdopteUnDev.DAO
{
    public class ReviewServices : UseBaseConnection, IRepository<Review>, IGetRepository<Review>
    {
        public void Delete(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Review] WHERE [idReview] = @id";
                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);

                    c.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //commenti sul developer
        public Review Get(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idReview],[ReviewName],[ReviewText],[ReviewMail],[ReviewDate],[idDev] FROM [Review] WHERE [idReview] = @id";
                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) return Mapper.ToReview(reader);
                    return null;
                }
            }
        }

        public IEnumerable<Review> Get()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idReview],[ReviewName],[ReviewText],[ReviewMail],[ReviewDate],[idDev] FROM [Review]";
                    
                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToReview(reader);
                }
            }
        }

        public int Insert(Review entity)
        {
            //non devo inserire la data, perché la DB inserisce quella del gg
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Review]([ReviewName],[ReviewText],[ReviewMail],[idDev]) OUTPUT [inserted].[idReview] VALUES (@nomRev, @txtRev, @emailRev,@idDevRev)";
                    SqlParameter p_nomRev = new SqlParameter("nomRev", entity.ReviewName);
                    SqlParameter p_txtRev = new SqlParameter("txtRev", entity.ReviewText);
                    SqlParameter p_emailRev = new SqlParameter("emailRev", entity.ReviewMail);
                    SqlParameter p_idDevRev = new SqlParameter("idDevRev", entity.idDev);

                    cmd.Parameters.Add(p_nomRev);
                    cmd.Parameters.Add(p_txtRev);
                    cmd.Parameters.Add(p_emailRev);
                    cmd.Parameters.Add(p_idDevRev);

                    c.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(int id, Review entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Review] SET [ReviewName]=@nomRev,[ReviewText]=@txtRev,[ReviewMail]=@emailRev,[idDev]=@idDevRev WHERE [idReview]=@idReview";

                    SqlParameter p_id = new SqlParameter("idReview", id);

                    SqlParameter p_nomRev = new SqlParameter("nomRev", entity.ReviewName);
                    SqlParameter p_txtRev = new SqlParameter("txtRev", entity.ReviewText);
                    SqlParameter p_emailRev = new SqlParameter("emailRev", entity.ReviewMail);
                    SqlParameter p_idDevRev = new SqlParameter("idDevRev", entity.idDev);

                    cmd.Parameters.Add(p_nomRev);
                    cmd.Parameters.Add(p_txtRev);
                    cmd.Parameters.Add(p_emailRev);
                    cmd.Parameters.Add(p_idDevRev);

                    c.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
