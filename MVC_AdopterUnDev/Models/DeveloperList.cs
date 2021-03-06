using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_AdopterUnDev.Models
{
    public class DeveloperList
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idDev { get; set; }

        [DisplayName(" Cognome ")]
        public string DevName { get; set; }

        [DisplayName(" Nome ")]
        public string DevFirstName { get; set; }

        [DisplayName(" Avatar ")]
        public string? DevPicture { get; set; }

        [DisplayName(" Costo per ora ")]
        public double DevHourCost { get; set; }

        [DisplayName(" Costo per giorno ")]
        public double DevDayCost { get; set; }
        [DisplayName(" Costo per mese ")]
        public double DevMonthCost { get; set; }
        

        //linguaggio principe
        [DisplayName(" Linguaggio base ")]
        public string linguaggio { get; set; }

        public string? DevCategPrincipal { get; set; }


    }
}
