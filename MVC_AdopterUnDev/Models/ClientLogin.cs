using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MVC_AdopterUnDev.Models
{
    public class ClientLogin
    {
        [Key]
        [ScaffoldColumn(false)]
        public int idClient { get; set; }
        [Required]
        [DisplayName("Cognome : ")]
        //[StringLength(100, MinimumLength = 2)]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Il Cognome deve essere minimo di 2 caratteri")]
        [DataType(DataType.Text)]
        public string CliName { get; set; }

        [Required]
        [DisplayName("Nome : ")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Il Nome deve essere minimo di 2 caratteri")]
        [DataType(DataType.Text)]
        public string CliFirstName { get; set; }

        [Required(ErrorMessage = "L'indirizzo e-mail é obbligatorio ")]
        [EmailAddress(ErrorMessage = "Inserire un'e-mail valida! )")]
        [DisplayName("E-mail : ")]
        [StringLength(maximumLength: 250, MinimumLength = 2)]
        [DataType(DataType.EmailAddress)]
        public string CliMail { get; set; }

        [Required]
        [DisplayName("Nome della Compagnia : ")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Il nome della Compagnia puo' avere  da 2  a max 100 caratteri")]
        [DataType(DataType.Text)]
        public string CliCompany { get; set; }


        //sono string e possono essere tranquillamente NULL ( x Number devo prendere 0)
        
        [DisplayName("Login : ")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        // lo autoriempio: CliCompany.CliName
        public string? CliLogin { 
            get {
                //se Nom e Prenon non sono nulli o sono solo spazi bianchi
                if (string.IsNullOrWhiteSpace(this.CliCompany) || string.IsNullOrWhiteSpace(this.CliName)) throw new FormatException();
                //prendo del cognome solo i primi 5 caratteri e se mi chiemo 'DE Castro' prendera xde.ca (dove x é la prima lettera del nome
                return this.CliCompany.Substring(0, 8).Replace(' ', '.') + this.CliName.Substring(0, 5);
            } 
        } 


        [Required]
        [DisplayName("Password : ")]
        [DataType(DataType.Password)]
        public string? CliPassword { get; set; }
    }
}
