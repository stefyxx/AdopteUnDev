using System;

namespace BLL_AdopteUnDev01.Models
{
    public class Client
    {
        public int idClient { get; set; }
        public string CliName { get; set; }
        public string CliFirstName { get; set; }
        public string CliMail { get; set; }
        public string CliCompany { get; set; }
        //sono string e possono essere tranquillamente NULL ( x Number devo prendere 0)
        public string? CliLogin { get; set; }
        public string? CliPassword { get; set; }
    }
}
