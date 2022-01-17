using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_AdopteUnDev.DTO
{
    public class Review
    {
        public int idReview { get; set; }
        
        //corto: nvarchar(50)
        public string ReviewName { get; set; }

        public string ReviewText { get; set; }
        public string ReviewMail { get; set; }

        //data per default del giorno
        public DateTime ReviewDate { 
            get;

            set;
        }
        public int idDev { get; set; }
    }
}
