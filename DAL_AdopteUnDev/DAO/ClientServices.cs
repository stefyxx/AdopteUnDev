using AdopteUnDev_Common.IRepositories;
using DAL_AdopteUnDev.DTO;
using DAL_AdopteUnDev.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_AdopteUnDev.DAO
{
    public class ClientServices : UseBaseConnection, IDeveloperRepository<Client>
    {
        public void Delete(int id)
        {
            using (SqlConnection c= new SqlConnection(_connString))
            {
                using(SqlCommand cmd = c.CreateCommand())
                {
                    //cmd.CommandText = "DELETE FROM [Client] WHERE [idClient] = @id";
                    
                    //Devo rendere NULL solo login e psw, per poter mantenere in memoria i dati anche se la società non é più cliente; immagina uno storico dei contratti
                    cmd.CommandText = "UPDATE [Client] SET [CliLogin]=NULL, [CliPassword]=NULL WHERE [idClient]=@id";
                    SqlParameter p_id = new SqlParameter("id", id);
                    cmd.Parameters.Add(p_id);

                    c.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Client Get(int id)
        {
            using(SqlConnection c = new SqlConnection(_connString))
            {
                using(SqlCommand cmd= c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idClient],[CliName],[CliFirstName],[CliMail],[CliCompany],[CliLogin] FROM [Client] WHERE [idClient] = @id";
                    SqlParameter p_id = new SqlParameter("id",id);
                    cmd.Parameters.Add(p_id);

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) return Mapper.ToClient(reader);
                    return null;
                }
            }
        }

        public IEnumerable<Client> Get()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idClient],[CliName],[CliFirstName],[CliMail],[CliCompany],[CliLogin] FROM [Client]";

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToClient(reader);
                }
            }
        }

        public int Insert(Client entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Client]([idClient],[CliName],[CliFirstName],[CliMail],[CliCompany],[CliLogin],[CliPassword]) OUTPUT [inserted].[idClient] VALUES (( SELECT MAX(idClient) FROM [Client])+1, @nom, @prenom, @email,@company,@login,@psw)";
                    SqlParameter p_nom = new SqlParameter("nom", entity.CliName);
                    SqlParameter p_pr = new SqlParameter("prenom", entity.CliFirstName);
                    SqlParameter p_email = new SqlParameter("email", entity.CliMail);
                    SqlParameter p_company = new SqlParameter("company", entity.CliCompany);
                    
                    //sono nullabili per poter mantenere in memoria i dati anche se la società non é più cliente; immagina uno storico dei contratti

                    //SqlParameter p_login = new SqlParameter("login", entity.CliLogin);
                    //SqlParameter p_login = new SqlParameter("login", (object)entity.CliLogin ?? DBNull.Value);

                    if (entity.CliLogin is null | entity.CliLogin == "")
                    {
                        SqlParameter p_login = new SqlParameter("psw", DBNull.Value);
                        cmd.Parameters.Add(p_login);
                    }
                    else
                    {
                        SqlParameter p_login = new SqlParameter("psw", entity.CliLogin);
                        cmd.Parameters.Add(p_login);

                    }

                    //SqlParameter p_psw = new SqlParameter("psw", entity.CliPassword);
                    //SqlParameter p_psw = new SqlParameter("psw", (object)entity.CliPassword ?? DBNull.Value);

                    if (entity.CliPassword is null | entity.CliPassword == "")
                    { 
                        SqlParameter p_psw = new SqlParameter("psw", DBNull.Value);
                        cmd.Parameters.Add(p_psw);
                    }
                    else
                    {
                        SqlParameter p_psw = new SqlParameter("psw",entity.CliPassword);
                        cmd.Parameters.Add(p_psw);

                    }

                    cmd.Parameters.Add(p_nom);
                    cmd.Parameters.Add(p_pr);
                    cmd.Parameters.Add(p_email);
                    cmd.Parameters.Add(p_company);
                    //cmd.Parameters.Add(p_login);
                    //cmd.Parameters.Add(p_psw);

                    c.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(int id, Client entity)
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Client] SET [CliName]=@nom, [CliFirstName]= @prenom, [CliMail]= @email, [CliCompany]= @company, [CliLogin]=@login, [CliPassword])=@psw " +
                        "WHERE [idClient] = @id";

                    SqlParameter p_id = new SqlParameter("id", id);

                    SqlParameter p_nom = new SqlParameter("nom", entity.CliName);
                    SqlParameter p_pr = new SqlParameter("prenom", entity.CliFirstName);
                    SqlParameter p_email = new SqlParameter("email", entity.CliMail);
                    SqlParameter p_company = new SqlParameter("company", entity.CliCompany);
                    //SqlParameter p_login = new SqlParameter("login", entity.CliLogin);
                    SqlParameter p_login = new SqlParameter("login", (object)entity.CliLogin ?? DBNull.Value);
                    //SqlParameter p_psw = new SqlParameter("psw", entity.CliPassword);
                    SqlParameter p_psw = new SqlParameter("psw", (object)entity.CliPassword ?? DBNull.Value);

                    cmd.Parameters.Add(p_id);
                    cmd.Parameters.Add(p_nom);
                    cmd.Parameters.Add(p_pr);
                    cmd.Parameters.Add(p_email);
                    cmd.Parameters.Add(p_company);
                    cmd.Parameters.Add(p_login);
                    cmd.Parameters.Add(p_psw);

                    c.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
