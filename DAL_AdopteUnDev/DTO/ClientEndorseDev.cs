using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_AdopteUnDev.DTO
{
    public class ClientEndorseDev
    {
        /*per utilizzarlo, lo devo convertire in string con il select:
         * DECLARE @myid uniqueidentifier = NEWID();  
         * SELECT CONVERT(nvarchar(255), @myid) AS 'char'
         opp : convert(nvarchar(36), requestID) as requestID*/
        public string EndorseNumber { get; set; }
        public int idClient { get; set; }
        public int idDev { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
