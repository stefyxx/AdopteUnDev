using AdopteUnDev_Common.IRepositories;
using DAL_AdopteUnDev.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_AdopteUnDev.DAO
{
    public class LangCategServices : UseBaseConnection, IGetRepository<LangCateg>
    {
        public LangCateg Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LangCateg> Get()
        {
            throw new NotImplementedException();
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
