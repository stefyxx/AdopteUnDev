using System;
namespace DAL_AdopteUnDev.DTO
{
    public class DevLang
    {
        //PK é una key combinata idDev+idIT
        public int idDev { get; set; }
        public int idIT { get; set; }
        public DateTime? Since { get; set; }
    }
}
