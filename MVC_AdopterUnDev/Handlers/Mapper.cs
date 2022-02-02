using BLL_AdopteUnDev01.Models ;
using MVC_AdopterUnDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_AdopterUnDev.Handlers
{
    public static class Mapper
    {
        public static DeveloperList ToListDev(this BLL_AdopteUnDev01.Models.Developer dev)
        {
            if (dev is null) return null;
            return new DeveloperList
            {
                idDev = dev.idDev,
                DevName = dev.DevName,
                DevFirstName = dev.DevFirstName,
                DevPicture = dev.DevPicture,
                DevHourCost = dev.DevHourCost,
                DevDayCost=dev.DevDayCost,
                DevMonthCost=dev.DevMonthCost,
                DevCategPrincipal=dev.DevCategPrincipal
            };
        }
        public static DeveloperDetails ToDetailsDev(this BLL_AdopteUnDev01.Models.Developer dev)
        {
            if (dev is null) return null;
            return new DeveloperDetails
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
                DevCategPrincipal = dev.DevCategPrincipal,
            };
        }

        public static DeveloperCreate ToCreateDev(this BLL_AdopteUnDev01.Models.Developer dev)
        {
            if (dev is null) return null;
            return new DeveloperCreate
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
                DevCategPrincipal = dev.DevCategPrincipal,
            };
        }
        
        
    }
}
