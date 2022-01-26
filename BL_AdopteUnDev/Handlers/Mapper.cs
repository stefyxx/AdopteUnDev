using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Handlers
{
    public static class Mapper
    {
        public static BLL_AdopteUnDev.Models.Developer ToBLL(this DAL_AdopteUnDev.DTO.Developer dev)
        {
            if (dev == null) return null;
            return new Models.Developer
            {
                idDev = dev.idDev,
                DevName = dev.DevName,
                DevFirstName = dev.DevFirstName,
                DevBirthDate = dev.DevBirthDate,
                DevPicture = dev.DevPicture,
                //DevPicture = (dev.DevPicture is null)?null:(string)dev.DevPicture,
                DevHourCost = dev.DevHourCost,
                DevDayCost = dev.DevDayCost,
                DevMonthCost = dev.DevMonthCost,
                DevMail = dev.DevMail,
                DevCategPrincipal = dev.DevCategPrincipal
            };
        }

        public static DAL_AdopteUnDev.DTO.Developer ToDAL(this BLL_AdopteUnDev.Models.Developer dev)
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
    }
}
