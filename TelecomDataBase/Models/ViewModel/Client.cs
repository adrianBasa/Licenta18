﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelecomDataBase.Models.ViewModel
{
    public class ClientViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Campul Nume este obligatoriu")]

        public string Nume { get; set; }
        [Required(ErrorMessage = "Campul Prenume este obligatoriu")]
        public string Prenume { get; set; }
        [System.ComponentModel.DisplayName("CNP")]
        [MaxLength(13)]
        [MinLength(13)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Campul CNP este obligatoriu, trebuie sa contina 13 cifre")]
        [Required(ErrorMessage = "Campul CNP este obligatoriu")]
        public string CNP_CIF { get; set; }
        [Required(ErrorMessage = "Campul Judet este obligatoriu")]
        public string Judet { get; set; }
        [Required(ErrorMessage = "Campul Oras este obligatoriu")]
        public string Oras { get; set; }
        [Required(ErrorMessage = "Campul Adresa este obligatoriu")]
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Campul Email este obligatoriu")]
        [EmailAddress(ErrorMessage = "adresa de email nu este valida, trebuie folosit @ pentru validare")]
        public string Email { get; set; }
        [MaxLength(10)]
        [MinLength(10)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Campul Numar Telefon este obligatoriu, trebuie sa contina 10 cifre")]
        public string Telefon { get; set; }
    }
}