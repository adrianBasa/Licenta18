using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelecomDataBase.Models.ViewModel
{
    public  class ProdusViewModel
    {
       
       

        public int ID { get; set; }

        [System.ComponentModel.DisplayName("Nume Produs")]
        [Required(ErrorMessage = "Campul Nume Produs  este obligatoriu.")]
        public string Nume_Produs { get; set; }

        [Required(ErrorMessage = "Campul Pret este obligatoriu.")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "Pretul trebuie sa contina doar cifre")]
        public int? Pret { get; set; }

        [System.ComponentModel.DisplayName("Descriere Produs")]
        [Required(ErrorMessage = "Campul Descriere Produs este obligatoriu.")]
        public string Descriere_Produc { get; set; }

       
    }
}
