using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_AdopterUnDev.Models
{
    public class DeveloperDelete
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idDev { get; set; }

        [DisplayName("Cognome : ")]
        public string DevName { get; set; }

        [DisplayName("Nome : ")]
        public string DevFirstName { get; set; }

        [DisplayName("E-mail : ")]
        public string DevMail { get; set; }

        [Required]
        [DisplayName("Siete sicuri di voler cancellare il Developer?")]
        public bool Validate { get; set; }

    }
}
