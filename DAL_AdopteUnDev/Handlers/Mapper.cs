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
                CliLogin =(string)record[nameof(Client.CliLogin)]

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
                DevPicture = (string)record[nameof(Developer.DevPicture)],
                DevHourCost = (double)record[nameof(Developer.DevHourCost)],
                DevDayCost = (double)record[nameof(Developer.DevDayCost)],
                DevMonthCost = (double)record[nameof(Developer.DevMonthCost)],
                DevMail = (string)record[nameof(Developer.DevMail)],
                DevCategPrincipal = (string)record[nameof(Developer.DevCategPrincipal)]
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
    }
}
