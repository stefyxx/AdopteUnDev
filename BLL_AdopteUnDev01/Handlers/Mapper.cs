using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_AdopteUnDev01.Handlers
{
    public static class Mapper
    {
        public static BLL_AdopteUnDev01.Models.Developer ToBLL(this DAL_AdopteUnDev.DTO.Developer dev)
        {
            if (dev == null) return null;
            return new Models.Developer
            {
                idDev = dev.idDev,
                DevName = dev.DevName,
                DevFirstName = dev.DevFirstName,
                DevBirthDate = dev.DevBirthDate,
                DevPicture = dev.DevPicture,
                //una string puo' essere NULL tranquilmente
                //DevPicture = (dev.DevPicture is null)?null:(string)dev.DevPicture,
                DevHourCost = dev.DevHourCost,
                DevDayCost = dev.DevDayCost,
                DevMonthCost = dev.DevMonthCost,
                DevMail = dev.DevMail,
                DevCategPrincipal = dev.DevCategPrincipal
            };
        }

        public static DAL_AdopteUnDev.DTO.Developer ToDAL(this BLL_AdopteUnDev01.Models.Developer dev)
        {
            if (dev == null) return null;
            return new DAL_AdopteUnDev.DTO.Developer
            {
                idDev = dev.idDev,
                DevName = dev.DevName,
                DevFirstName = dev.DevFirstName,
                DevBirthDate = dev.DevBirthDate,
                DevPicture = dev.DevPicture,
                DevHourCost = dev.DevHourCost,
                DevDayCost = dev.DevDayCost,
                DevMonthCost = dev.DevMonthCost,
                DevMail = dev.DevMail,
                DevCategPrincipal = dev.DevCategPrincipal
            };
        }

        public static BLL_AdopteUnDev01.Models.Client ToBLL(this DAL_AdopteUnDev.DTO.Client client)
        {
            if (client == null) return null;
            return new Models.Client
            {
                idClient = client.idClient,
                CliName = client.CliName,
                CliFirstName = client.CliFirstName,
                CliMail = client.CliMail,
                CliCompany = client.CliCompany,
                //una string puo' essere NULL tranquilmente
                //CliLogin = (client.CliLogin is null)?null:(string)client.CliLogin,
                CliLogin = client.CliLogin,
                CliPassword = client.CliPassword
            };
        }

        public static DAL_AdopteUnDev.DTO.Client ToDAL(this BLL_AdopteUnDev01.Models.Client client)
        {
            if (client == null) return null;
            return new DAL_AdopteUnDev.DTO.Client
            {
                idClient = client.idClient,
                CliName = client.CliName,
                CliFirstName = client.CliFirstName,
                CliMail = client.CliMail,
                CliCompany = client.CliCompany,
                CliLogin = client.CliLogin,
                CliPassword = client.CliPassword

            };
        }
    }
}
