using AdopteUnDev_Common.IRepositories;
using DAL_AdopteUnDev.DTO;
using DAL_AdopteUnDev.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_AdopteUnDev.DAO
{
    public class LangCategServices : UseBaseConnection, IGetRepository<LangCateg>
    {
        //N.B. non ha una colonna Id, ha una key primary associata: idLang+idCateg
        public LangCateg Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LangCateg> Get()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [idIT],[idCategory] FROM [Categories]";

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToLangCateg(reader);
                }
            }
        }

        //ottenere label del linguaggio con le categorie associate:
        public IEnumerable<LangCateg> GetListLabels()
        {
            using (SqlConnection c = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT [Categories].[CategLabel], [ITLang].[ITLabel], [Categories].[idCategory], [ITLang].[idIT] FROM[Categories] INNER JOIN " +
                        "[LangCateg] ON[Categories].[idCategory] = [LangCateg].[idCategory] INNER JOIN " +
                        "[ITLang] ON[LangCateg].[idIT] = [ITLang].[idIT]";

                    c.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToLangCateg(reader); // mancano 2 obj: Linguaggio e CATEGORIA

                }
            }
        }




        //ottenere label del linguaggio con le categorie associate:
        /*SELECT [Categories].[CategLabel], [ITLang].[ITLabel], [Categories].[idCategory], [ITLang].[idIT]
         * FROM [Categories] INNER JOIN
         * [LangCateg] ON [Categories].[idCategory] = [LangCateg].[idCategory] INNER JOIN
         * [ITLang] ON [LangCateg].[idIT] = [ITLang].[idIT]
         */
        /*Procedura stoccata:
         * CREATE PROCEDURE nome
         * AS
         * SELECT [Categories].[CategLabel], [ITLang].[ITLabel], [Categories].[idCategory], [ITLang].[idIT]
         * FROM [Categories] INNER JOIN
         *          [LangCateg] ON [Categories].[idCategory] = [LangCateg].[idCategory] INNER JOIN
         *          [ITLang] ON [LangCateg].[idIT] = [ITLang].[idIT]
         
         */

        //ho linguaggio, categoria ,idLinguaggio, IdCategoria
        /* SELECT [Categories].[CategLabel], [ITLang].[ITLabel], [Categories].[idCategory], [ITLang].[idIT]
         * FROM [Categories] LEFT OUTER JOIN
         * [LangCateg] ON [Categories].[idCategory] = [LangCateg].[idCategory]
         * RIGHT OUTER JOIN [ITLang] ON [LangCateg].[idIT] = [ITLang].[idIT]
         */
        //ho tutti i linguaggi, anche senza Categoria ; con id linguaggio e id categoria(gli id posso non pas afficher):
        /*SELECT [Categories].[CategLabel], [ITLang].[ITLabel], [Categories].[idCategory], [ITLang].[idIT]
         * FROM [Categories] INNER JOIN
         * [LangCateg] ON [Categories].[idCategory] = [LangCateg].[idCategory]
         * RIGHT OUTER JOIN [ITLang] ON [LangCateg].[idIT] = [ITLang].[idIT]
         */
    }
}
