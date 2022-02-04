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

        //login lo dono io, non lo deve modificare
        [DisplayName("Login : ")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string? CliLogin { get; }

        [Required]
        [DisplayName("Password : ")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\S+$).{8,20}$", ErrorMessage = "Le mot de passe doit au minimum un nombre, une minuscule, une majuscule, un caractère parmis '@#$%^&-+=()', aucun espace blanc, compris entre 8 et 20 caractères.")]
        public string? CliPassword { get; set; }

        [Required]
        public bool Validate { get; set; }


    }
}
