//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelecomDataBase.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Produs
    {
        public Produs()
        {
            this.Comandas = new HashSet<Comanda>();
        }
    
        public int ID { get; set; }
        public string Nume_Produs { get; set; }
        public Nullable<int> Pret { get; set; }
        public string Descriere_Produc { get; set; }
    
        public virtual ICollection<Comanda> Comandas { get; set; }
    }
}
