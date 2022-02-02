﻿using System;
using System.Collections.Generic;
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
        public string DevName { get; set; }
        public string DevFirstName { get; set; }
        //public DateTime DevBirthDate { get; set; }
        public string? DevPicture { get; set; }
        public double DevHourCost { get; set; }
        public double DevDayCost { get; set; }
        public double DevMonthCost { get; set; }
        //public string DevMail { get; set; }

        //linguaggio principe
        public string? DevCategPrincipal { get; set; }
    }
}
