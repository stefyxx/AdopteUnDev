using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MVC_AdopterUnDev.Models
{
    public class DeveloperEdit
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idDev { get; set; }

        [Required]
        [DisplayName("Cognome : ")]
        public string DevName { get; set; }

        [Required]
        [DisplayName("Nome : ")]
        public string DevFirstName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data di nascita : ")]
        public DateTime DevBirthDate { get; set; }

        [DisplayName("Avatar : ")]
        public string? DevPicture { get; set; }

        [Required]
        [DisplayName("Costo per ora : ")]
        public double DevHourCost { get; set; }

        [Required]
        [DisplayName("Costo per giorno : ")]
        public double DevDayCost { get; set; }

        [Required]
        [DisplayName("Costo per mese : ")]
        public double DevMonthCost { get; set; }

        [Required(ErrorMessage = "L'indirizzo e-mail é obbligatorio ")]
        [EmailAddress(ErrorMessage = "Inserire un'e-mail valida! )")]
        [DisplayName("E-mail : ")]
        public string DevMail { get; set; }

        // é l'idIT int cast in toString()
        [DisplayName("Linguaggio principale : ")] //linguaggio principe
        public string? DevCategPrincipal { get; set; }

        //cosi' ha sia id che label
        public IEnumerable<DAL_AdopteUnDev.DTO.ITLang> langues { get; set; }
    }
}
