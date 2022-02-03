using DAL_AdopteUnDev.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL_AdopteUnDev.Handlers
{
    public static class Mapper
    {
        public static Client ToClient(IDataRecord record)
        {
            if (record is null) return null;
            return new Client
            {
                idClient= (int)record[nameof(Client.idClient)],
                CliName= (string)record[nameof(Client.CliName)],
                CliFirstName=(string)record[nameof(Client.CliFirstName)],
                CliMail=(string)record[nameof(Client.CliMail)],
                CliCompany=(string)record[nameof(Client.CliCompany)],
                //CliLogin =(string)record[nameof(Client.CliLogin)],
                CliLogin = (record[nameof(Client.CliLogin)]==DBNull.Value)?null:(string)record[nameof(Client.CliLogin)]

            };
        }

        public static Developer ToDeveloper(IDataRecord record)
        {
            if (record is null) return null;
            return new Developer
            {
                idDev = (int)record[nameof(Developer.idDev)],
                DevName = (string)record[nameof(Developer.DevName)],
                DevFirstName = (string)record[nameof(Developer.DevFirstName)],
                DevBirthDate = (DateTime)record[nameof(Developer.DevBirthDate)],
                //DevPicture = (string)record[nameof(Developer.DevPicture)],
                DevPicture =(record[nameof(Developer.DevPicture)]==DBNull.Value)?null: (string)record[nameof(Developer.DevPicture)],
                DevHourCost = (double)record[nameof(Developer.DevHourCost)],
                DevDayCost = (double)record[nameof(Developer.DevDayCost)],
                DevMonthCost = (double)record[nameof(Developer.DevMonthCost)],
                DevMail = (string)record[nameof(Developer.DevMail)],
                //DevCategPrincipal = (string)record[nameof(Developer.DevCategPrincipal)]
                DevCategPrincipal =(record[nameof(Developer.DevCategPrincipal)]==DBNull.Value)?null: (string)record[nameof(Developer.DevCategPrincipal)]
            };
        }
        public static Categories ToCategories(IDataRecord record)
        {
            if (record is null) return null;
            return new Categories
            {
                idCategory = (int)record[nameof(Categories.idCategory)],
                CategLabel =(string)record[nameof(Categories.CategLabel)]
            };
        }

        public static ITLang ToITLang(IDataRecord record)
        {
            if (record is null) return null;
            return new ITLang
            {
                idIT = (int)record[nameof(ITLang.idIT)],
                ITLabel = (string)record[nameof(ITLang.ITLabel)]
            };
        }

        public static LangCateg ToLangCateg(IDataRecord record)
        {
            if (record is null) return null;
            return new LangCateg
            {
                idIT = (int)record[nameof(LangCateg.idIT)],
                idCategory = (int)record[nameof(LangCateg.idCategory)]
            };
        }
        public static ClientEndorseDev ToClientEndorseDev(IDataRecord record)
        {
            if (record is null) return null;
            return new ClientEndorseDev
            {
                EndorseNumber = (string)record[nameof(ClientEndorseDev.EndorseNumber)],
                idClient = (int)record[nameof(ClientEndorseDev.idClient)],
                idDev =(int)record[nameof(ClientEndorseDev.idDev)],
                BeginDate=(DateTime)record[nameof(ClientEndorseDev.BeginDate)],
                EndDate = (DateTime)record[nameof(ClientEndorseDev.EndDate)]
            };
        }
        public static DevLang ToDevLang(IDataRecord record)
        {
            if (record is null) return null;
            return new DevLang
            {
                idDev = (int)record[nameof(DevLang.idDev)],
                idIT = (int)record[nameof(DevLang.idIT)],
                //NB DateTime? !!!!!
                Since = record[nameof(DevLang.Since)] != DBNull.Value ? (DateTime?)record[nameof(DevLang.Since)] : null
            };
        }
        public static Review ToReview(IDataRecord record)
        {
            if (record is null) return null;
            return new Review
            {
                idReview = (int)record[nameof(Review.idReview)],
                ReviewName = (string)record[nameof(Review.ReviewName)],
                ReviewText = (string)record[nameof(Review.ReviewText)],
                ReviewMail = (string)record[nameof(Review.ReviewMail)],
                ReviewDate = (DateTime)record[nameof(Review.ReviewDate)],
                idDev = (int)record[nameof(Review.idDev)]
            };

        }
    }
}
