using AdopteUnDev_Common.IRepositories;
using DAL_AdopteUnDev.DTO;
using DAL_AdopteUnDev.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_AdopteUnDev.DAO
{
    public class DeveloperServices : UseBaseConnection, IDeveloperRepository<Developer>
    {
        public void Delete(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    //potrebbe essere piu' corretto; aah!! bisogna dotarli di login!!:
                    //cmd.CommandText = "UPDATE [Developer] SET login=Null, psw=null WHERE [idDev]=@id ";
                    cmd.CommandText = "DELETE FROM [Developer] WHERE [idDev] = @id";
                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);

                    c.Open();
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public Developer Get(int id)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idDev],[DevName],[DevFirstName],[DevBirthDate],[DevPicture],[DevHourCost],[DevDayCost], [DevMonthCost], [DevMail], [DevCategPrincipal] FROM [Developer] WHERE [idDev] = @id";
                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) return Mapper.ToDeveloper(reader);
                    return null;
                }
            }
        }

        public IEnumerable<Developer> Get()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idDev],[DevName],[DevFirstName],[DevBirthDate],[DevPicture],[DevHourCost],[DevDayCost],[DevMonthCost], [DevMail], [DevCategPrincipal] FROM [Developer]";

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToDeveloper(reader);
                }
            }
        }

        public int Insert(Developer entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {

                    cmd.CommandText = "INSERT INTO [Developer] ([idDev],[DevName], [DevFirstName], [DevBirthDate], [DevPicture], [DevHourCost], [DevDayCost], [DevMonthCost], [DevMail], [DevCategPrincipal]) OUTPUT [inserted].[idDev] VALUES (( SELECT MAX(idDev) FROM [Developer])+1, @nom, @prenom, @data, @f, @costoOra, @costoGiorno, @costoMese, @email, @categoriaPrinc)";
                    SqlParameter p_nom = new SqlParameter("nom", entity.DevName);
                    SqlParameter p_pr = new SqlParameter("prenom", entity.DevFirstName);
                    SqlParameter p_nascita = new SqlParameter("data", entity.DevBirthDate);
                    //non converte direttamente in nullo 
                    SqlParameter p_foto = new SqlParameter("f", (object)entity.DevPicture ?? DBNull.Value);
                    SqlParameter p_costoOra = new SqlParameter("costoOra", entity.DevHourCost);
                    SqlParameter p_costoGiorno = new SqlParameter("costoGiorno", entity.DevDayCost);
                    SqlParameter p_costoMese = new SqlParameter("costoMese", entity.DevMonthCost);
                    SqlParameter p_email = new SqlParameter("email", entity.DevMail);
                    SqlParameter p_categoriaPrinc = new SqlParameter("categoriaPrinc", (object)entity.DevCategPrincipal ?? DBNull.Value);
                    /* stessa cosa di:
                     * SqlParameter p_foto = command.Parameters.AddWithValue("@f", entity.DevPicture);
                        if (entity.DevPicture == null)
                        {
                            entity.DevPicture.Value = DBNull.Value;
                        }
                     */

                    cmd.Parameters.Add(p_nom);
                    cmd.Parameters.Add(p_pr);
                    cmd.Parameters.Add(p_nascita);
                    cmd.Parameters.Add(p_foto);
                    cmd.Parameters.Add(p_costoOra);
                    cmd.Parameters.Add(p_costoGiorno);
                    cmd.Parameters.Add(p_costoMese);
                    cmd.Parameters.Add(p_email);
                    cmd.Parameters.Add(p_categoriaPrinc);

                    c.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(int id, Developer entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Developer] SET [DevName]=@nom, [DevFirstName]= @prenom, [DevBirthDate]=@dataDiNascita, [DevPicture]=@foto, [DevHourCost]=@costoOra, [DevDayCost]=@costoGiorno, [DevMonthCost]=@costoMese, [DevMail]= @email, [DevCategPrincipal]= @categoriaPrinc WHERE [idDev] = @id";

                    SqlParameter p_id = new SqlParameter("id", id);

                    SqlParameter p_nom = new SqlParameter("nom", entity.DevName);
                    SqlParameter p_pr = new SqlParameter("prenom", entity.DevFirstName);
                    SqlParameter p_nascita = new SqlParameter("dataDiNascita", entity.DevBirthDate);
                    //SqlParameter p_foto = new SqlParameter("foto", entity.DevPicture);
                    SqlParameter p_foto = new SqlParameter("foto", (Object)entity.DevPicture ?? DBNull.Value);
                    SqlParameter p_costoOra = new SqlParameter("costoOra", entity.DevHourCost);
                    SqlParameter p_costoGiorno = new SqlParameter("costoGiorno", entity.DevDayCost);
                    SqlParameter p_costoMese = new SqlParameter("costoMese", entity.DevMonthCost);
                    SqlParameter p_email = new SqlParameter("email", entity.DevMail);
                    //SqlParameter p_categoriaPrinc = new SqlParameter("categoriaPrinc", entity.DevCategPrincipal);
                    SqlParameter p_categoriaPrinc = new SqlParameter("categoriaPrinc", (Object)entity.DevCategPrincipal ?? DBNull.Value);

                    cmd.Parameters.Add(p_nom);
                    cmd.Parameters.Add(p_pr);
                    cmd.Parameters.Add(p_nascita);
                    cmd.Parameters.Add(p_foto);
                    cmd.Parameters.Add(p_costoOra);
                    cmd.Parameters.Add(p_costoGiorno);
                    cmd.Parameters.Add(p_costoMese);
                    cmd.Parameters.Add(p_email);
                    cmd.Parameters.Add(p_categoriaPrinc);

                    c.Open();

                    cmd.ExecuteNonQuery();
                    
                }
            }
        }
    }
}
